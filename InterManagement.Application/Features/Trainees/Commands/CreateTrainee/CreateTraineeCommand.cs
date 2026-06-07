using InterManagement.Application.Features.Trainees.DTOs;

namespace InterManagement.Application.Features.Trainees.Commands.CreateTrainee
{

    // ======================================================
    // CLASSE COMMAND POUR CRÉER UN STAGIAIRE
    // ======================================================

    // class CreateTraineeCommand → nom de la commande
    // Une Command = une ENVELOPPE qui transporte les données vers le Handler
    // Elle ne contient AUCUNE logique, juste des données
    public class CreateTraineeCommand
    {
        // CreateTraineeDto → le type de la propriété (c'est le DTO)
        public CreateTraineeDto Data { get; set; }
    
    
        // (CreateTraineeDto data) → paramètre : reçoit le DTO du client
        public CreateTraineeCommand(CreateTraineeDto data)    

        {
            Data = data;
        }
    }
}
































































/*namespace InterManagement.Application.Features.Trainees.DTOs
{
    public class CreateTraineeDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
*/

/*

// ======================================================
// IMPORTATION (USING)
// ======================================================

// Importe le DTO CreateTraineeDto depuis le dossier DTOs
// Ce DTO contient les données que le client a envoyées (FirstName, Email, etc.)
using InterManagement.Application.Features.Trainees.DTOs;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Commands/CreateTrainee/
namespace InterManagement.Application.Features.Trainees.Commands.CreateTrainee;

// ======================================================
// CLASSE COMMAND POUR CRÉER UN STAGIAIRE
// ======================================================

// public → accessible par le Controller et par le Handler
// class CreateTraineeCommand → nom de la commande
// Une Command = une ENVELOPPE qui transporte les données vers le Handler
// Elle ne contient AUCUNE logique, juste des données
public class CreateTraineeCommand
{
    // ==================================================
    // PROPRIÉTÉ : Data
    // ==================================================
    
    // public → accessible de l'extérieur (le Handler va y accéder)
    // CreateTraineeDto → le type de la propriété (c'est le DTO)
    // Data → nom de la propriété
    // { get; set; } → on peut lire et écrire cette propriété
    public CreateTraineeDto Data { get; set; }

    // ==================================================
    // CONSTRUCTEUR
    // ==================================================
    
    // public → accessible de l'extérieur
    // CreateTraineeCommand → nom du constructeur (identique à la classe)
    // (CreateTraineeDto data) → paramètre : reçoit le DTO du client
    public CreateTraineeCommand(CreateTraineeDto data)
    {
        // Data = data → stocke le paramètre reçu dans la propriété Data
        // Le Handler pourra récupérer les données avec command.Data.FirstName
        Data = data;
    }
}

// ======================================================
// À RETENIR SUR CETTE CLASSE
// ======================================================

// 1. Cette classe ne fait RIEN d'autre que transporter des données
// 2. Le constructeur est OBLIGATOIRE pour créer la commande avec les données
// 3. La propriété Data contient TOUTES les données du formulaire
// 4. Le Handler récupérera les données avec command.Data.FirstName
// 5. C'est le pattern CQRS : Command = ce qu'on demande de faire

// ======================================================
// UTILISATION DANS LE CONTROLLER (exemple)
// ======================================================

// Dans TraineeController.cs :
// [HttpPost]
// public async Task<IActionResult> Create([FromBody] CreateTraineeDto request)
// {
//     // Création de la commande avec les données reçues
//     var command = new CreateTraineeCommand(request);
//     
//     // Envoi de la commande au Handler
//     var result = await _handler.Handle(command);
//     
//     return Ok(result);
// }

// ======================================================
// UTILISATION DANS LE HANDLER (exemple)
// ======================================================

// Dans CreateTraineeHandler.cs :
// public async Task<TraineeDto> Handle(CreateTraineeCommand command)
// {
//     // Récupération des données
//     var firstName = command.Data.FirstName;  // "Moussa"
//     var email = command.Data.Email;          // "moussa@email.com"
//     var university = command.Data.University; // "ESMT"
//     
//     // ... traitement ...
// }

*/





//> "`CreateTraineeCommand` est une **enveloppe** qui transporte les données.

//> **D'où viennent les données ?** Du `CreateTraineeDto` qui a été créé automatiquement par ASP.NET à partir du JSON envoyé par le client.

//> **Où vont les données ?** Vers le `CreateTraineeHandler` qui va les utiliser pour créer le stagiaire.

