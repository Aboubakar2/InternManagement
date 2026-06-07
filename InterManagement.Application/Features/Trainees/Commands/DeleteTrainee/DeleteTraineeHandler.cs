using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Trainees.Commands.DeleteTrainee
{
    public class DeleteTraineeHandler
    {
        private readonly ITraineeRepository _repository;

        public DeleteTraineeHandler(ITraineeRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteTraineeCommand command)
        {
            // 1. Chercher le stagiaire
            var trainee = await _repository.GetByIdAsync(command.Id);
            if (trainee == null)
                throw new TraineeNotFoundException(command.Id);

            // 2. Supprimer (soft delete)
            await _repository.DeleteAsync(command.Id);
        }
    }
}

































































/*

// ======================================================
// IMPORTATIONS (USING)
// ======================================================

// Importe les exceptions personnalisées (TraineeNotFoundException)
using InterManagement.Domain.Exceptions;

// Importe l'interface ITraineeRepository pour accéder à la base de données
using InterManagement.Domain.Repositories;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Commands/DeleteTrainee/
namespace InterManagement.Application.Features.Trainees.Commands.DeleteTrainee;

// ======================================================
// CLASSE HANDLER POUR SUPPRIMER UN STAGIAIRE
// ======================================================

// public → accessible par le Controller
// class DeleteTraineeHandler → nom du Handler
// Un Handler = le CERVEAU qui exécute la logique de la commande
public class DeleteTraineeHandler
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
    // DeleteTraineeHandler → nom du constructeur (identique à la classe)
    // ITraineeRepository repository → paramètre reçu (injection de dépendances)
    public DeleteTraineeHandler(ITraineeRepository repository)
    {
        // Stocke le repository reçu dans le champ _repository
        // Le Handler pourra maintenant appeler _repository.GetByIdAsync()
        _repository = repository;
    }

    // ==================================================
    // MÉTHODE PRINCIPALE : Handle
    // ==================================================
    
    // public → accessible par le Controller
    // async → méthode asynchrone (ne bloque pas pendant l'accès base)
    // Task → retourne RIEN (juste une indication que l'opération est terminée)
    // Handle → nom standard CQRS (exécute la commande)
    // DeleteTraineeCommand command → reçoit la commande avec l'Id
    public async Task Handle(DeleteTraineeCommand command)
    {
        // ==============================================
        // ÉTAPE 1 : CHERCHER LE STAGIAIRE
        // ==============================================
        
        // Appelle le repository pour récupérer le stagiaire par son Id
        // command.Id → récupère l'Id depuis la commande
        // await → attend que la base de données réponde
        // trainee = l'objet Trainee si trouvé, null si non trouvé
        var trainee = await _repository.GetByIdAsync(command.Id);
        
        // Si le stagiaire n'existe pas (trainee == null)
        if (trainee == null)
            // Lance une exception personnalisée avec l'Id en message
            // L'exécution s'arrête ici, rien après n'est exécuté
            throw new TraineeNotFoundException(command.Id);

        // ==============================================
        // ÉTAPE 2 : SUPPRIMER (SOFT DELETE)
        // ==============================================
        
        // Appelle le repository pour supprimer le stagiaire
        // DeleteAsync(command.Id) :
        //   - Récupère le stagiaire par son Id
        //   - Met IsDeleted = true (soft delete)
        //   - Met UpdatedAt = DateTime.UtcNow
        //   - Sauvegarde en base
        //   - L'enregistrement reste en base mais est caché par HasQueryFilter
        await _repository.DeleteAsync(command.Id);
    }
}

// ======================================================
// RÉSUMÉ DU FLUX
// ======================================================

// 1. Le Controller reçoit l'Id dans l'URL : DELETE /api/trainees/5
// 2. Le Controller crée DeleteTraineeCommand avec l'Id
// 3. Le Controller appelle Handle(command)
// 
// 4. Le Handler :
//    a) Cherche le stagiaire dans la base avec GetByIdAsync(5)
//    b) Si non trouvé → lance TraineeNotFoundException
//    c) Si trouvé → appelle DeleteAsync(5)
//    d) DeleteAsync fait le soft delete : IsDeleted = true
// 
// 5. Le Handler termine (retourne Task, rien d'autre)
// 6. Le Controller retourne NoContent() (204)

// ======================================================
// COMPARAISON AVEC LES AUTRES HANDLERS
// ======================================================

// CreateTraineeHandler :
//   - Vérifie que l'email n'existe pas
//   - Crée une entité
//   - Sauvegarde
//   - Retourne TraineeDto (avec l'Id généré)

// UpdateTraineeHandler :
//   - Vérifie que le stagiaire existe
//   - Modifie les propriétés
//   - Sauvegarde
//   - Retourne TraineeDto (version modifiée)

// DeleteTraineeHandler :
//   - Vérifie que le stagiaire existe
//   - Appelle DeleteAsync (soft delete)
//   - Ne retourne RIEN (Task)

// ======================================================
// POURQUOI PAS DE RETOUR ?
// ======================================================

// Après une suppression, le client n'a pas besoin de données.
// Il a juste besoin de savoir si ça a marché :
//   - 204 NoContent = supprimé avec succès
//   - 404 NotFound = stagiaire n'existe pas (exception attrapée par le Controller)

// ======================================================
// À RETENIR
// ======================================================

// 1. Le Handler vérifie TOUJOURS que le stagiaire existe avant d'agir
// 2. DeleteAsync fait un SOFT DELETE (IsDeleted = true), pas une suppression physique
// 3. Le Handler ne retourne rien (Task)
// 4. Si le stagiaire n'existe pas → exception TraineeNotFoundException

*/