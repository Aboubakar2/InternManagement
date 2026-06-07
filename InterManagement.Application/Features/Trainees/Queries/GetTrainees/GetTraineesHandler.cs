using InterManagement.Application.Features.Trainees.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Trainees.Queries.GetTrainees
{
    public class GetTraineesHandler
    {
        private readonly ITraineeRepository _repository;

        public GetTraineesHandler(ITraineeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TraineeDto>> Handle(GetTraineesQuery query)
        {
            // 1. Lire depuis la base avec filtre optionnel
            var trainees = await _repository.GetAllWithFiltersAsync(query.Status);

            // 2. Transformer en DTOs et retourner
            return trainees.Select(t => new TraineeDto
            {
                Id         = t.Id,
                FirstName  = t.FirstName,
                LastName   = t.LastName,
                Email      = t.Email,
                University = t.University,
                Specialty  = t.Specialty,
                Theme      = t.Theme,
                StartDate  = t.StartDate,
                EndDate    = t.EndDate,
                Status     = t.Status,
                IsActive   = t.IsActive
            });
        }
    }
}


/*


// ======================================================
// IMPORTATIONS (USING)
// ======================================================

// Importe les DTOs (TraineeDto) depuis le dossier DTOs
// TraineeDto est ce qu'on va retourner au client (liste)
using InterManagement.Application.Features.Trainees.DTOs;

// Importe les entités (Trainee, TraineeStatus) depuis le Domain
using InterManagement.Domain.Entities;

// Importe l'interface ITraineeRepository pour accéder à la base de données
using InterManagement.Domain.Repositories;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Queries/GetTrainees/
namespace InterManagement.Application.Features.Trainees.Queries.GetTrainees;

// ======================================================
// CLASSE HANDLER POUR RÉCUPÉRER LA LISTE DES STAGIAIRES
// ======================================================

// public → accessible par le Controller
// class GetTraineesHandler → nom du Handler
// Un Handler = le CERVEAU qui exécute la logique de la requête
// C'est une QUERY (lecture seule, pas de modification)
public class GetTraineesHandler
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
    // GetTraineesHandler → nom du constructeur
    // ITraineeRepository repository → paramètre reçu
    public GetTraineesHandler(ITraineeRepository repository)
    {
        // Stocke le repository reçu dans le champ _repository
        _repository = repository;
    }

    // ==================================================
    // MÉTHODE PRINCIPALE : Handle
    // ==================================================
    
    // public → accessible par le Controller
    // async → méthode asynchrone
    // Task<IEnumerable<TraineeDto>> → retourne UNE LISTE de TraineeDto
    // Handle → nom standard CQRS
    // GetTraineesQuery query → reçoit la requête avec les filtres (optionnels)
    public async Task<IEnumerable<TraineeDto>> Handle(GetTraineesQuery query)
    {
        // ==============================================
        // ÉTAPE 1 : LIRE DEPUIS LA BASE AVEC FILTRE OPTIONNEL
        // ==============================================
        
        // Appelle le repository pour récupérer les stagiaires
        // GetAllWithFiltersAsync(query.Status) :
        //   - Si query.Status = null → retourne TOUS les stagiaires
        //   - Si query.Status = InProgress → retourne seulement les "En cours"
        //   - Le filtre est appliqué DIRECTEMENT dans la base de données
        //     (plus performant que de filtrer en mémoire)
        var trainees = await _repository.GetAllWithFiltersAsync(query.Status);

        // ==============================================
        // ÉTAPE 2 : TRANSFORMER EN DTOS ET RETOURNER
        // ==============================================
        
        // trainees.Select(...) : convertit CHAQUE entité Trainee en TraineeDto
        // C'est une projection : on prend seulement les champs nécessaires
        // On ne retourne PAS les propriétés internes (CreatedAt, UpdatedAt, IsDeleted)
        // On ne retourne PAS les relations (Phases, Evaluations)
        return trainees.Select(t => new TraineeDto
        {
            // Identifiant (important pour le client)
            Id         = t.Id,
            
            // Identité
            FirstName  = t.FirstName,
            LastName   = t.LastName,
            Email      = t.Email,
            
            // Informations académiques
            University = t.University,
            Specialty  = t.Specialty,
            Theme      = t.Theme,
            
            // Dates
            StartDate  = t.StartDate,
            EndDate    = t.EndDate,
            
            // Statuts
            Status     = t.Status,      // InProgress, Completed, etc.
            IsActive   = t.IsActive     // true = compte actif
        });
    }
}

// ======================================================
// RÉSUMÉ DU FLUX
// ======================================================

// 1. Le Controller reçoit un paramètre optionnel : GET /api/trainees?status=1
// 2. Le Controller crée GetTraineesQuery avec Status = 1
// 3. Le Controller appelle Handle(query)
// 
// 4. Le Handler :
//    a) Appelle _repository.GetAllWithFiltersAsync(query.Status)
//    b) La base retourne la liste filtrée (ou tous si Status = null)
//    c) Transforme CHAQUE Trainee en TraineeDto
//    d) Retourne la liste de TraineeDto
// 
// 5. Le Controller reçoit IEnumerable<TraineeDto>
// 6. Le Controller retourne Ok(liste)

// ======================================================
// COMPARAISON AVEC GetTraineeByIdHandler
// ======================================================

// GetTraineesHandler (LISTE) :
//   - Retourne IEnumerable<TraineeDto> (PLUSIEURS stagiaires)
//   - Utilise GetAllWithFiltersAsync (filtre possible)
//   - DTO sans relations (léger)
//   - Utilisé pour l'affichage tableau

// GetTraineeByIdHandler (DÉTAIL) :
//   - Retourne TraineeDetailDto (UN stagiaire)
//   - Utilise GetWithPhasesAsync (charge les relations)
//   - DTO avec relations (complet)
//   - Utilisé pour la page détail

// ======================================================
// POURQUOI .Select() ?
// ======================================================

// .Select() est une méthode LINQ qui transforme chaque élément d'une collection
// 
// Sans .Select() : on retournerait les entités directement → danger !
// Avec .Select() : on crée un nouveau DTO pour chaque entité → contrôle total

// Exemple :
// Liste d'entités : [Trainee, Trainee, Trainee]
// .Select(t => new TraineeDto { ... })
// Résultat : [TraineeDto, TraineeDto, TraineeDto]

// ======================================================
// CE QUE LE CLIENT REÇOIT (JSON)
// ======================================================

// GET /api/trainees
// Réponse :
// [
//   {
//     "id": 5,
//     "firstName": "Moussa",
//     "lastName": "Diallo",
//     "email": "moussa@email.com",
//     "status": 1,
//     "isActive": true
//   },
//   {
//     "id": 6,
//     "firstName": "Aisha",
//     "lastName": "Bah",
//     "email": "aisha@email.com",
//     "status": 1,
//     "isActive": true
//   }
// ]

// ======================================================
// CE QUE LE CLIENT NE VOIT PAS
// ======================================================

// - CreatedAt (date de création en base)
// - UpdatedAt (date de modification)
// - IsDeleted (soft delete)
// - Phases (collection)
// - Evaluations (collection)
// - Feedbacks (collection)
// - Files (collection)

// ======================================================
// À RETENIR
// ======================================================

// 1. C'est une QUERY → ne modifie PAS la base
// 2. Utilise GetAllWithFiltersAsync pour appliquer le filtre directement en base
// 3. Retourne une LISTE de TraineeDto (pas un seul)
// 4. Utilise .Select() pour convertir chaque entité en DTO
// 5. Ne retourne PAS les relations (listes légères = performance)
// 6. Le filtre Status est optionnel (nullable)


*/






/*
using InterManagement.Domain.Repositories;
using InterManagement.Application.Features.Trainees.DTOs;

namespace InterManagement.Application.Features.Trainees.Queries.GetTrainees
{
    public class GetTraineesHandler
    {
        private readonly ITraineeRepository _repository;
        
        public GetTraineesHandler(ITraineeRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<TraineeDto>> Handle(GetTraineesQuery query)
        {
            // 1. Récupérer les stagiaires depuis la base
            var trainees = await _repository.GetAllAsync();
            
            // 2. Appliquer les filtres (si présents)
            if (!string.IsNullOrEmpty(query.Status))
            {
                trainees = trainees.Where(t => t.Status.ToString() == query.Status);
            }
            
            if (!string.IsNullOrEmpty(query.Specialty))
            {
                trainees = trainees.Where(t => t.Specialty == query.Specialty);
            }
            
            // 3. Convertir en DTO et retourner
            return trainees.Select(t => new TraineeDto
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                University = t.University,
                Specialty = t.Specialty,
                Theme = t.Theme,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Status = t.Status.ToString(),
                IsActive = t.IsActive
            });
        }
    }
}




*/