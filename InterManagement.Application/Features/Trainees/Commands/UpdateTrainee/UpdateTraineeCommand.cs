
using InterManagement.Application.Features.Trainees.DTOs;

namespace InterManagement.Application.Features.Trainees.Commands.UpdateTrainee
{
    public class UpdateTraineeCommand
    {
        public int Id { get; set; }
        public UpdateTraineeDto Data { get; set; }

        public UpdateTraineeCommand(int id, UpdateTraineeDto data)
        {
            Id   = id;
            Data = data;
        }
    }
}












































/*
// ======================================================
// IMPORTATION (USING)
// ======================================================

// Importe le DTO UpdateTraineeDto depuis le dossier DTOs
// Ce DTO contient les données que le client a envoyées pour la modification
using InterManagement.Application.Features.Trainees.DTOs;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Commands/UpdateTrainee/
namespace InterManagement.Application.Features.Trainees.Commands.UpdateTrainee;

// ======================================================
// CLASSE COMMAND POUR MODIFIER UN STAGIAIRE
// ======================================================

// public → accessible par le Controller et par le Handler
// class UpdateTraineeCommand → nom de la commande
// Une Command = une ENVELOPPE qui transporte les données vers le Handler
public class UpdateTraineeCommand
{
    // ==================================================
    // PROPRIÉTÉ 1 : Id
    // ==================================================
    
    // public → accessible de l'extérieur
    // int → type de l'identifiant (le stagiaire à modifier)
    // Id → nom de la propriété
    // { get; set; } → on peut lire et écrire cette propriété
    public int Id { get; set; }

    // ==================================================
    // PROPRIÉTÉ 2 : Data
    // ==================================================
    
    // public → accessible de l'extérieur
    // UpdateTraineeDto → le type de la propriété (c'est le DTO)
    // Data → nom de la propriété
    // { get; set; } → on peut lire et écrire cette propriété
    public UpdateTraineeDto Data { get; set; }

    // ==================================================
    // CONSTRUCTEUR
    // ==================================================
    
    // public → accessible de l'extérieur
    // UpdateTraineeCommand → nom du constructeur (identique à la classe)
    // (int id, UpdateTraineeDto data) → deux paramètres :
    //    - id : l'identifiant du stagiaire à modifier
    //    - data : le DTO avec les nouvelles données
    public UpdateTraineeCommand(int id, UpdateTraineeDto data)
    {
        // Stocke l'Id reçu dans la propriété Id
        Id = id;
        
        // Stocke le DTO reçu dans la propriété Data
        Data = data;
    }
}

// ======================================================
// COMPARAISON AVEC LES AUTRES COMMANDS
// ======================================================

// CreateTraineeCommand :
//   - Contient UNIQUEMENT un DTO (CreateTraineeDto)
//   - PAS d'Id (la base le génère)
//   - Constructeur : (CreateTraineeDto data)

// UpdateTraineeCommand :
//   - Contient Id + DTO (UpdateTraineeDto)
//   - Id = lequel modifier
//   - DTO = nouvelles données
//   - Constructeur : (int id, UpdateTraineeDto data)

// DeleteTraineeCommand :
//   - Contient UNIQUEMENT l'Id
//   - PAS de DTO (pas besoin)
//   - Constructeur : (int id)

// ======================================================
// POURQUOI ID ET DATA SÉPARÉS ?
// ======================================================

// L'Id identifie QUEL stagiaire modifier
// Le DTO contient QUELLES données utiliser pour la modification
// Ils sont séparés car ils viennent d'endroits différents :
//   - Id vient de l'URL (PUT /api/trainees/5)
//   - Data vient du body de la requête (le JSON)

// ======================================================
// UTILISATION DANS LE CONTROLLER (exemple)
// ======================================================

// Dans TraineeController.cs :
// [HttpPut("{id}")]
// public async Task<IActionResult> Update(int id, [FromBody] UpdateTraineeDto request)
// {
//     // Création de la commande avec :
//     //   - l'Id reçu dans l'URL
//     //   - le DTO reçu dans le body
//     var command = new UpdateTraineeCommand(id, request);
//     
//     // Envoi de la commande au Handler
//     var result = await _handler.Handle(command);
//     
//     return Ok(result);
// }

// ======================================================
// UTILISATION DANS LE HANDLER (exemple)
// ======================================================

// Dans UpdateTraineeHandler.cs :
// public async Task<TraineeDto> Handle(UpdateTraineeCommand command)
// {
//     // Récupération de l'Id
//     var id = command.Id;  // 5
//     
//     // Récupération des nouvelles données
//     var firstName = command.Data.FirstName;  // "Moussa Ahmed" (modifié)
//     var status = command.Data.Status;        // "Completed" (modifié)
//     
//     // ... traitement ...
// }

// ======================================================
// EXEMPLE DE REQUÊTE COMPLÈTE
// ======================================================

// URL : PUT /api/trainees/5
// Body (JSON) :
// {
//   "firstName": "Moussa Ahmed",
//   "lastName": "Diallo Thiam",
//   "status": 2
// }

// Dans le Controller :
//   id = 5 (vient de l'URL)
//   request.FirstName = "Moussa Ahmed"
//   request.Status = 2

// Création de la commande :
//   command.Id = 5
//   command.Data.FirstName = "Moussa Ahmed"
//   command.Data.Status = 2

// ======================================================
// À RETENIR
// ======================================================

// 1. UpdateTraineeCommand a DEUX propriétés : Id ET Data
// 2. L'Id identifie le stagiaire à modifier (vient de l'URL)
// 3. Data contient les nouvelles données (vient du body JSON)
// 4. Le constructeur reçoit les deux paramètres

*/