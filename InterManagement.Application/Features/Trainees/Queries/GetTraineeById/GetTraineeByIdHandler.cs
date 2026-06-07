using InterManagement.Application.Features.Trainees.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Trainees.Queries.GetTraineeById
{
    public class GetTraineeByIdHandler
    {
        private readonly ITraineeRepository _repository;

        public GetTraineeByIdHandler(ITraineeRepository repository)
        {
            _repository = repository;
        }

        public async Task<TraineeDetailDto> Handle(GetTraineeByIdQuery query)
        {
            // 1. Chercher avec ses phases
            var trainee = await _repository.GetWithPhasesAsync(query.Id);
            if (trainee == null)
                throw new TraineeNotFoundException(query.Id);

            // 2. Retourner le DTO détaillé
            return new TraineeDetailDto
            {
                Id         = trainee.Id,
                FirstName  = trainee.FirstName,
                LastName   = trainee.LastName,
                Email      = trainee.Email,
                University = trainee.University,
                Specialty  = trainee.Specialty,
                Theme      = trainee.Theme,
                StartDate  = trainee.StartDate,
                EndDate    = trainee.EndDate,
                Status     = trainee.Status,
                IsActive   = trainee.IsActive
            };
        }
    }
}



/*
// ======================================================
// IMPORTATIONS (USING)
// ======================================================

// Importe les DTOs (TraineeDetailDto) depuis le dossier DTOs
using InterManagement.Application.Features.Trainees.DTOs;

// Importe les exceptions personnalisées (TraineeNotFoundException)
using InterManagement.Domain.Exceptions;

// Importe l'interface ITraineeRepository pour accéder à la base de données
using InterManagement.Domain.Repositories;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Queries/GetTraineeById/
namespace InterManagement.Application.Features.Trainees.Queries.GetTraineeById;

// ======================================================
// CLASSE HANDLER POUR RÉCUPÉRER UN STAGIAIRE PAR SON ID
// ======================================================

// public → accessible par le Controller
// class GetTraineeByIdHandler → nom du Handler
// Un Handler = le CERVEAU qui exécute la logique de la requête
// C'est une QUERY (lecture seule, pas de modification)
public class GetTraineeByIdHandler
{
    // ==================================================
    // CHAMP (VARIABLE DE CLASSE)
    // ==================================================
    
    // private → seulement cette classe peut l'utiliser
    // readonly → une fois assignée, on ne peut plus la modifier
    // ITraineeRepository → l'interface qui permet d'accéder à la base
    // _repository → le nom de la variable
    private readonly ITraineeRepository _repository;

    // ==================================================
    // CONSTRUCTEUR
    // ==================================================
    
    // public → accessible par l'injection de dépendances
    // GetTraineeByIdHandler → nom du constructeur
    // ITraineeRepository repository → paramètre reçu
    public GetTraineeByIdHandler(ITraineeRepository repository)
    {
        // Stocke le repository reçu dans le champ _repository
        _repository = repository;
    }

    // ==================================================
    // MÉTHODE PRINCIPALE : Handle
    // ==================================================
    
    // public → accessible par le Controller
    // async → méthode asynchrone
    // Task<TraineeDetailDto> → retourne un TraineeDetailDto (détail complet)
    // Handle → nom standard CQRS
    // GetTraineeByIdQuery query → reçoit la requête avec l'Id
    public async Task<TraineeDetailDto> Handle(GetTraineeByIdQuery query)
    {
        // ==============================================
        // ÉTAPE 1 : CHERCHER LE STAGIAIRE AVEC SES PHASES
        // ==============================================
        
        // Appelle le repository pour récupérer le stagiaire par son Id
        // GetWithPhasesAsync(query.Id) → charge AUSSI les phases (Include)
        // C'est différent de GetByIdAsync qui charge juste le stagiaire
        // await → attend que la base réponde
        var trainee = await _repository.GetWithPhasesAsync(query.Id);
        
        // Si le stagiaire n'existe pas
        if (trainee == null)
            // Lance une exception personnalisée
            throw new TraineeNotFoundException(query.Id);

        // ==============================================
        // ÉTAPE 2 : RETOURNER LE DTO DÉTAILLÉ
        // ==============================================
        
        // Crée un TraineeDetailDto avec toutes les informations
        // Ce DTO est PLUS COMPLET que TraineeDto
        // Il pourra contenir les relations (Phases, Evaluations, etc.)
        return new TraineeDetailDto
        {
            Id         = trainee.Id,          // Identifiant
            FirstName  = trainee.FirstName,   // Prénom
            LastName   = trainee.LastName,    // Nom
            Email      = trainee.Email,       // Email
            University = trainee.University,  // Université
            Specialty  = trainee.Specialty,   // Spécialité
            Theme      = trainee.Theme,       // Thème du stage
            StartDate  = trainee.StartDate,   // Date début
            EndDate    = trainee.EndDate,     // Date fin
            Status     = trainee.Status,      // Statut (InProgress, Completed...)
            IsActive   = trainee.IsActive     // Compte actif ou non
        };
    }
}

// ======================================================
// RÉSUMÉ DU FLUX
// ======================================================

// 1. Le Controller reçoit l'Id dans l'URL : GET /api/trainees/5
// 2. Le Controller crée GetTraineeByIdQuery avec l'Id
// 3. Le Controller appelle Handle(query)
// 
// 4. Le Handler :
//    a) Cherche le stagiaire avec GetWithPhasesAsync(5)
//       (charge le stagiaire ET ses phases en une seule requête)
//    b) Si non trouvé → TraineeNotFoundException
//    c) Si trouvé → crée un TraineeDetailDto
// 
// 5. Le Handler retourne TraineeDetailDto
// 6. Le Controller retourne Ok(TraineeDetailDto)

// ======================================================
// DIFFÉRENCE ENTRE GetByIdHandler ET GetTraineesHandler
// ======================================================

// GetTraineesHandler (POUR LA LISTE) :
//   - Utilise GetAllAsync() (pas de Include)
//   - Retourne IEnumerable<TraineeDto> (plusieurs)
//   - DTO sans relations (plus léger)

// GetTraineeByIdHandler (POUR LE DÉTAIL) :
//   - Utilise GetWithPhasesAsync() (avec Include)
//   - Retourne TraineeDetailDto (un seul)
//   - DTO avec relations (plus complet)

// ======================================================
// POURQUOI GetWithPhasesAsync ET PAS GetByIdAsync ?
// ======================================================

// GetByIdAsync(5) :
//   - Charge SEULEMENT le stagiaire
//   - trainee.Phases = [] (vide)
//   - Faudrait une deuxième requête pour charger les phases

// GetWithPhasesAsync(5) :
//   - Charge le stagiaire ET ses phases en UNE requête (JOIN)
//   - trainee.Phases contient les vraies phases
//   - SQL généré : SELECT t.*, p.* FROM trainees t LEFT JOIN phases p...

// ======================================================
// COMPARAISON AVEC LES AUTRES HANDLERS
// ======================================================

// CreateTraineeHandler (COMMAND) :
//   - Modifie la base (INSERT)
//   - A des validations (email unique)
//   - Retourne TraineeDto

// UpdateTraineeHandler (COMMAND) :
//   - Modifie la base (UPDATE)
//   - Vérifie que le stagiaire existe et est actif
//   - Retourne TraineeDto

// DeleteTraineeHandler (COMMAND) :
//   - Modifie la base (soft delete)
//   - Vérifie que le stagiaire existe
//   - Ne retourne rien

// GetTraineeByIdHandler (QUERY) :
//   - NE modifie PAS la base (SELECT seulement)
//   - Vérifie que le stagiaire existe
//   - Retourne TraineeDetailDto (avec relations)

// ======================================================
// À RETENIR
// ======================================================

// 1. C'est une QUERY → ne modifie PAS la base
// 2. Utilise GetWithPhasesAsync pour charger les relations
// 3. Retourne TraineeDetailDto (plus complet que TraineeDto)
// 4. Si non trouvé → TraineeNotFoundException
// 5. Pas de validation particulière (juste existence)




*/