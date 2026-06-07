
namespace InterManagement.Application.Features.Trainees.Commands.DeleteTrainee
{
    public class DeleteTraineeCommand
    {
        public int Id { get; set; }

        public DeleteTraineeCommand(int id)
        {
            Id = id;
        }
    }
}


























































/*

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Commands/DeleteTrainee/
namespace InterManagement.Application.Features.Trainees.Commands.DeleteTrainee;

// ======================================================
// CLASSE COMMAND POUR SUPPRIMER UN STAGIAIRE
// ======================================================

// public → accessible par le Controller et par le Handler
// class DeleteTraineeCommand → nom de la commande
// Une Command = une ENVELOPPE qui transporte les données vers le Handler
public class DeleteTraineeCommand
{
    // ==================================================
    // PROPRIÉTÉ : Id
    // ==================================================
    
    // public → accessible de l'extérieur
    // int → type de l'identifiant (le stagiaire à supprimer)
    // Id → nom de la propriété
    // { get; set; } → on peut lire et écrire cette propriété
    public int Id { get; set; }

    // ==================================================
    // CONSTRUCTEUR
    // ==================================================
    
    // public → accessible de l'extérieur
    // DeleteTraineeCommand → nom du constructeur (identique à la classe)
    // (int id) → paramètre : reçoit l'Id du stagiaire à supprimer
    public DeleteTraineeCommand(int id)
    {
        // Id = id → stocke le paramètre reçu dans la propriété Id
        // Le Handler pourra récupérer l'Id avec command.Id
        Id = id;
    }
}

// ======================================================
// COMPARAISON AVEC LES AUTRES COMMANDS
// ======================================================

// CreateTraineeCommand :
//   - Contient un DTO avec TOUTES les données (FirstName, Email, etc.)
//   - Constructeur reçoit CreateTraineeDto

// UpdateTraineeCommand :
//   - Contient un Id + un DTO avec les données modifiables
//   - Constructeur reçoit (int id, UpdateTraineeDto data)

// DeleteTraineeCommand :
//   - Contient JUSTE un Id
//   - Constructeur reçoit (int id)
//   - PAS de DTO car on n'a besoin que de l'Id pour supprimer

// ======================================================
// POURQUOI SEULEMENT L'ID ?
// ======================================================

// Pour supprimer un stagiaire, on a besoin de savoir LEQUEL supprimer.
// On n'a pas besoin de ses autres informations (nom, email, etc.).
// L'Id est suffisant pour identifier le stagiaire dans la base.

// ======================================================
// UTILISATION DANS LE CONTROLLER (exemple)
// ======================================================

// Dans TraineeController.cs :
// [HttpDelete("{id}")]
// public async Task<IActionResult> Delete(int id)
// {
//     // Création de la commande avec l'Id reçu dans l'URL
//     var command = new DeleteTraineeCommand(id);
//     
//     // Envoi de la commande au Handler
//     await _handler.Handle(command);
//     
//     return NoContent();  // 204 = supprimé avec succès
// }

// ======================================================
// UTILISATION DANS LE HANDLER (exemple)
// ======================================================

// Dans DeleteTraineeHandler.cs :
// public async Task Handle(DeleteTraineeCommand command)
// {
//     // Récupération de l'Id
//     var id = command.Id;  // 5
//     
//     // Suppression du stagiaire
//     await _repository.DeleteAsync(id);
// }

// ======================================================
// À RETENIR
// ======================================================

// 1. DeleteTraineeCommand ne contient QUE l'Id
// 2. Pas besoin de DTO car pas de données à envoyer
// 3. Le Handler retourne Task (rien) car pas de données à retourner
// 4. L'Id vient de l'URL (DELETE /api/trainees/5), pas du body


*/