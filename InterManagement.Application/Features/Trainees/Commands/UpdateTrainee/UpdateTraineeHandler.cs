using InterManagement.Application.Features.Trainees.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Trainees.Commands.UpdateTrainee
{
    public class UpdateTraineeHandler
    {
        private readonly ITraineeRepository _repository;

        public UpdateTraineeHandler(ITraineeRepository repository)
        {
            _repository = repository;
        }

        public async Task<TraineeDto> Handle(UpdateTraineeCommand command)
        {
            // 1. Chercher le stagiaire
            var trainee = await _repository.GetByIdAsync(command.Id);
            if (trainee == null)
                throw new TraineeNotFoundException(command.Id);

            // 2. Vérifier qu'il est actif
            if (!trainee.IsActive)
                throw new TraineeNotActiveException(command.Id);

            // 3. Modifier les champs
            trainee.Update(
                command.Data.FirstName,
                command.Data.LastName,
                command.Data.Email,
                command.Data.University,
                command.Data.Specialty,
                command.Data.Theme,
                command.Data.StartDate,
                command.Data.EndDate,
                command.Data.Status
            );

            
            // 4. Sauvegarder
            await _repository.UpdateAsync(trainee);

            // 5. Retourner le DTO
            return new TraineeDto
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

// Importe les DTOs (TraineeDto) depuis le dossier DTOs
using InterManagement.Application.Features.Trainees.DTOs;

// Importe les exceptions personnalisées (TraineeNotFoundException, TraineeNotActiveException)
using InterManagement.Domain.Exceptions;

// Importe l'interface ITraineeRepository pour accéder à la base de données
using InterManagement.Domain.Repositories;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Commands/UpdateTrainee/
namespace InterManagement.Application.Features.Trainees.Commands.UpdateTrainee;

// ======================================================
// CLASSE HANDLER POUR MODIFIER UN STAGIAIRE
// ======================================================

// public → accessible par le Controller
// class UpdateTraineeHandler → nom du Handler
// Un Handler = le CERVEAU qui exécute la logique de la commande
public class UpdateTraineeHandler
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
    // UpdateTraineeHandler → nom du constructeur (identique à la classe)
    // ITraineeRepository repository → paramètre reçu (injection de dépendances)
    public UpdateTraineeHandler(ITraineeRepository repository)
    {
        // Stocke le repository reçu dans le champ _repository
        _repository = repository;
    }

    // ==================================================
    // MÉTHODE PRINCIPALE : Handle
    // ==================================================
    
    // public → accessible par le Controller
    // async → méthode asynchrone (ne bloque pas pendant l'accès base)
    // Task<TraineeDto> → retourne un TraineeDto de façon asynchrone
    // Handle → nom standard CQRS (exécute la commande)
    // UpdateTraineeCommand command → reçoit la commande avec l'Id et les données
    public async Task<TraineeDto> Handle(UpdateTraineeCommand command)
    {
        // ==============================================
        // ÉTAPE 1 : VÉRIFIER QUE LE STAGIAIRE EXISTE
        // ==============================================
        
        // Appelle le repository pour récupérer le stagiaire par son Id
        // command.Id → récupère l'Id depuis la commande
        // await → attend que la base de données réponde
        var trainee = await _repository.GetByIdAsync(command.Id);
        
        // Si le stagiaire n'existe pas (trainee == null)
        if (trainee == null)
            // Lance une exception personnalisée avec l'Id en message
            // L'exécution s'arrête ici
            throw new TraineeNotFoundException(command.Id);

        // ==============================================
        // ÉTAPE 2 : VÉRIFIER QUE LE STAGIAIRE EST ACTIF
        // ==============================================
        
        // !trainee.IsActive = "trainee n'est PAS actif"
        // Si le stagiaire est désactivé (IsActive = false)
        if (!trainee.IsActive)
            // Lance une exception personnalisée
            // On ne peut pas modifier un stagiaire inactif
            throw new TraineeNotActiveException(command.Id);

        // ==============================================
        // ÉTAPE 3 : MODIFIER LES CHAMPS
        // ==============================================
        
        // On remplace chaque propriété de l'entité existante
        // par la nouvelle valeur envoyée par le client
        // command.Data.FirstName → nouvelle valeur
        // trainee.FirstName → ancienne valeur (sera écrasée)
        
        // Identité
        trainee.FirstName  = command.Data.FirstName;   // "Moussa" → "Moussa Ahmed"
        trainee.LastName   = command.Data.LastName;     // "Diallo" → "Diallo Thiam"
        trainee.Email      = command.Data.Email;        // "m@email.com" → "nouveau@email.com"
        
        // Informations académiques
        trainee.University = command.Data.University;   // "ESMT" → "UCAD"
        trainee.Specialty  = command.Data.Specialty;    // "Informatique" → "Réseaux"
        trainee.Theme      = command.Data.Theme;        // "Dev Web" → "IA"
        
        // Dates
        trainee.StartDate  = command.Data.StartDate;    // "2025-01-06" → "2025-02-01"
        trainee.EndDate    = command.Data.EndDate;      // "2025-04-27" → "2025-05-30"
        
        // Statut (spécifique à Update)
        trainee.Status     = command.Data.Status;       // InProgress → Completed

        // Note : UpdatedAt sera mis à jour automatiquement par le Repository
        // dans la méthode UpdateAsync (entity.UpdatedAt = DateTime.UtcNow)

        // ==============================================
        // ÉTAPE 4 : SAUVEGARDER EN BASE
        // ==============================================
        
        // Appelle le repository pour sauvegarder les modifications
        // UpdateAsync(trainee) :
        //   - Marque l'entité comme modifiée
        //   - Met UpdatedAt = DateTime.UtcNow
        //   - Exécute SaveChangesAsync()
        //   - SQL généré : UPDATE trainees SET ... WHERE Id = X
        await _repository.UpdateAsync(trainee);

        // ==============================================
        // ÉTAPE 5 : RETOURNER LE DTO
        // ==============================================
        
        // Retourne un TraineeDto avec les données mises à jour
        // Le client reçoit la version modifiée sans faire une nouvelle requête
        return new TraineeDto
        {
            Id         = trainee.Id,          // 5 (inchangé)
            FirstName  = trainee.FirstName,   // "Moussa Ahmed" (modifié)
            LastName   = trainee.LastName,    // "Diallo Thiam" (modifié)
            Email      = trainee.Email,       // "nouveau@email.com" (modifié)
            University = trainee.University,  // "UCAD" (modifié)
            Specialty  = trainee.Specialty,   // "Réseaux" (modifié)
            Theme      = trainee.Theme,       // "IA" (modifié)
            StartDate  = trainee.StartDate,   // "2025-02-01" (modifié)
            EndDate    = trainee.EndDate,     // "2025-05-30" (modifié)
            Status     = trainee.Status,      // Completed (modifié)
            IsActive   = trainee.IsActive     // true (inchangé)
        };
    }
}

// ======================================================
// RÉSUMÉ DU FLUX
// ======================================================

// 1. Le Controller reçoit : 
//    - Id = 5 (dans l'URL)
//    - UpdateTraineeDto (dans le body JSON)
// 
// 2. Le Controller crée UpdateTraineeCommand avec (id, data)
// 
// 3. Le Controller appelle Handle(command)
// 
// 4. Le Handler :
//    a) Cherche le stagiaire Id=5
//    b) Vérifie qu'il existe
//    c) Vérifie qu'il est actif (IsActive = true)
//    d) Modifie les propriétés avec les nouvelles valeurs
//    e) Sauvegarde en base (UpdateAsync)
//    f) Retourne TraineeDto mis à jour
// 
// 5. Le Controller reçoit TraineeDto
// 6. Le Controller retourne Ok(TraineeDto)

// ======================================================
// COMPARAISON AVEC LES AUTRES HANDLERS
// ======================================================

// CreateTraineeHandler :
//   - Vérifie email unique
//   - Crée NOUVELLE entité
//   - AddAsync (INSERT)
//   - Retourne TraineeDto

// UpdateTraineeHandler :
//   - Vérifie que le stagiaire EXISTE
//   - Vérifie qu'il est ACTIF
//   - MODIFIE l'entité existante
//   - UpdateAsync (UPDATE)
//   - Retourne TraineeDto mis à jour

// DeleteTraineeHandler :
//   - Vérifie que le stagiaire EXISTE
//   - Pas de vérification d'activité
//   - DeleteAsync (soft delete)
//   - Ne retourne RIEN

// ======================================================
// À RETENIR
// ======================================================

// 1. On vérifie TOUJOURS que le stagiaire existe
// 2. On vérifie qu'il est actif avant modification
// 3. On modifie UNIQUEMENT les champs envoyés
// 4. UpdateAsync met automatiquement UpdatedAt à jour
// 5. On retourne le DTO mis à jour


*/