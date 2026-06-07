/*using InterManagement.Application.Features.Trainees.DTOs;

namespace InterManagement.Application.Features.Trainees.Queries.GetTrainees
{
    public class GetTraineesQuery
    {
        // Paramètres optionnels pour filtrer
        public string? Status { get; set; }      // Filtre par statut (ex: "Active")
        public string? Specialty { get; set; }   // Filtre par spécialité (ex: "Informatique")
        
        public GetTraineesQuery(string? status = null, string? specialty = null)
        {
            Status = status;
            Specialty = specialty;
        }
    }
}
*/

using InterManagement.Domain.Entities;

namespace InterManagement.Application.Features.Trainees.Queries.GetTrainees
{
    public class GetTraineesQuery
    {
        public TraineeStatus? Status { get; set; }
        // ? = optionnel
        // null    → retourne tous les stagiaires
        // Active  → retourne seulement les actifs
    }
}




/*


// ======================================================
// IMPORTATION (USING)
// ======================================================

// Importe l'enum TraineeStatus depuis le Domain
// TraineeStatus est un enum avec les valeurs : Pending, InProgress, Completed, Suspended
using InterManagement.Domain.Entities;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Queries/GetTrainees/
namespace InterManagement.Application.Features.Trainees.Queries.GetTrainees;

// ======================================================
// CLASSE QUERY POUR RÉCUPÉRER LA LISTE DES STAGIAIRES
// ======================================================

// public → accessible par le Controller et par le Handler
// class GetTraineesQuery → nom de la query
// Une Query = une ENVELOPPE qui transporte les paramètres vers le Handler
// C'est une REQUÊTE de LECTURE (ne modifie pas la base)
public class GetTraineesQuery
{
    // ==================================================
    // PROPRIÉTÉ : Status (FILTRE OPTIONNEL)
    // ==================================================
    
    // public → accessible de l'extérieur
    // TraineeStatus? → le ? signifie que la valeur est NULLABLE (peut être null)
    // Status → nom de la propriété
    // { get; set; } → on peut lire et écrire
    public TraineeStatus? Status { get; set; }
    
    // ==================================================
    // EXPLICATION DU ? (NULLABLE)
    // ==================================================
    
    // Sans ? (TraineeStatus) :
    //   - La propriété DOIT avoir une valeur
    //   - Ne peut pas être null
    //   - Utilisation : query.Status = TraineeStatus.InProgress
    
    // Avec ? (TraineeStatus?) :
    //   - La propriété PEUT être null
    //   - Null signifie "pas de filtre"
    //   - Utilisation : query.Status = null  (pas de filtre)
    //                 ou query.Status = TraineeStatus.InProgress (filtre)
}

// ======================================================
// COMMENTAIRES INTÉGRÉS DANS LE CODE
// ======================================================

// // ? = optionnel
// // null    → retourne tous les stagiaires
// // Active  → retourne seulement les actifs

// Ces commentaires expliquent le comportement :
//   - Si Status = null → pas de filtre → retourne TOUS les stagiaires
//   - Si Status = TraineeStatus.InProgress → filtre → retourne seulement ceux "En cours"

// ======================================================
// EXEMPLES D'UTILISATION
// ======================================================

// Exemple 1 : Pas de filtre (retourne tous les stagiaires)
// var query = new GetTraineesQuery();
// query.Status = null;  // ou on ne met rien
// Handler va faire : SELECT * FROM trainees

// Exemple 2 : Filtre sur les stagiaires "En cours"
// var query = new GetTraineesQuery();
// query.Status = TraineeStatus.InProgress;
// Handler va faire : SELECT * FROM trainees WHERE Status = 1

// Exemple 3 : Filtre sur les stagiaires "Terminés"
// var query = new GetTraineesQuery();
// query.Status = TraineeStatus.Completed;
// Handler va faire : SELECT * FROM trainees WHERE Status = 2

// ======================================================
// COMPARAISON AVEC LES AUTRES QUERIES/COMMANDS
// ======================================================

// GetTraineeByIdQuery :
//   - Contient Id (obligatoire, pas nullable)
//   - Cherche UN stagiaire précis

// GetTraineesQuery :
//   - Contient Status (optionnel, nullable)
//   - Cherche UNE LISTE de stagiaires

// DeleteTraineeCommand :
//   - Contient Id (obligatoire)
//   - Supprime un stagiaire

// ======================================================
// UTILISATION DANS LE CONTROLLER (exemple)
// ======================================================

// Dans TraineeController.cs :
// [HttpGet]
// public async Task<IActionResult> GetAll([FromQuery] TraineeStatus? status)
// {
//     // Création de la query avec le paramètre reçu
//     var query = new GetTraineesQuery();
//     query.Status = status;  // peut être null ou une valeur
//     
//     // Envoi de la query au Handler
//     var result = await _handler.Handle(query);
//     
//     return Ok(result);
// }

// Appel API possibles :
//   GET /api/trainees           → status = null → tous les stagiaires
//   GET /api/trainees?status=1  → status = InProgress → seulement "En cours"

// ======================================================
// UTILISATION DANS LE HANDLER (exemple)
// ======================================================

// Dans GetTraineesHandler.cs :
// public async Task<IEnumerable<TraineeDto>> Handle(GetTraineesQuery query)
// {
//     var trainees = await _repository.GetAllAsync();
//     
//     // Si Status n'est pas null, on filtre
//     if (query.Status.HasValue)
//     {
//         trainees = trainees.Where(t => t.Status == query.Status.Value);
//     }
//     
//     return trainees.Select(t => new TraineeDto { ... });
// }

// ======================================================
// POURQUOI UNE PROPRIÉTÉ NULLABLE ?
// ======================================================

// Le ? permet d'avoir TROIS états possibles pour une requête :
// 
// 1. Status = null        → "je ne veux PAS de filtre"
// 2. Status = InProgress  → "filtre sur InProgress"
// 3. Status = Completed   → "filtre sur Completed"
// 
// Sans le ?, on ne peut avoir que les états 2 et 3.
// On ne pourrait PAS avoir "pas de filtre".

// ======================================================
// À RETENIR
// ======================================================

// 1. GetTraineesQuery a une propriété Status NULLABLE (TraineeStatus?)
// 2. Null = pas de filtre → retourne tous les stagiaires
// 3. Une valeur = filtre → retourne seulement ceux avec ce statut
// 4. Le ? permet d'avoir un filtre OPTIONNEL
// 5. C'est utilisé pour la recherche/filtrage dans la liste

*/