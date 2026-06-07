namespace InterManagement.Application.Features.Trainees.Queries.GetTraineeById
{
    public class GetTraineeByIdQuery
    {
        public int Id { get; set; }  
        
        public GetTraineeByIdQuery(int id)
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
// Correspond au chemin : Application/Features/Trainees/Queries/GetTraineeById/
namespace InterManagement.Application.Features.Trainees.Queries.GetTraineeById;

// ======================================================
// CLASSE QUERY POUR RÉCUPÉRER UN STAGIAIRE PAR SON ID
// ======================================================

// public → accessible par le Controller et par le Handler
// class GetTraineeByIdQuery → nom de la query
// Une Query = une ENVELOPPE qui transporte les paramètres vers le Handler
// C'est une REQUÊTE de LECTURE (ne modifie pas la base)
public class GetTraineeByIdQuery
{
    // ==================================================
    // PROPRIÉTÉ : Id
    // ==================================================
    
    // public → accessible de l'extérieur
    // int → type de l'identifiant
    // Id → nom de la propriété
    // { get; set; } → on peut lire et écrire cette propriété
    public int Id { get; set; }

    // ==================================================
    // CONSTRUCTEUR
    // ==================================================
    
    // public → accessible de l'extérieur
    // GetTraineeByIdQuery → nom du constructeur (identique à la classe)
    // (int id) → paramètre : reçoit l'Id du stagiaire à récupérer
    public GetTraineeByIdQuery(int id)
    {
        // Id = id → stocke le paramètre reçu dans la propriété Id
        // Le Handler pourra récupérer l'Id avec query.Id
        Id = id;
    }
}

// ======================================================
// COMPARAISON AVEC LES COMMANDS
// ======================================================

// CreateTraineeCommand :
//   - Contient un DTO avec TOUTES les données
//   - Utilisé pour ÉCRIRE (INSERT)

// UpdateTraineeCommand :
//   - Contient Id + DTO
//   - Utilisé pour ÉCRIRE (UPDATE)

// DeleteTraineeCommand :
//   - Contient JUSTE l'Id
//   - Utilisé pour ÉCRIRE (DELETE)

// GetTraineeByIdQuery :
//   - Contient JUSTE l'Id (comme DeleteTraineeCommand)
//   - Utilisé pour LIRE (SELECT)
//   - Différence : c'est une QUERY, pas une COMMAND

// ======================================================
// POURQUOI SEULEMENT L'ID ?
// ======================================================

// Pour récupérer un stagiaire spécifique, on a besoin de savoir LEQUEL.
// On n'a pas besoin d'autres informations.
// L'Id est suffisant pour identifier le stagiaire dans la base.
// Le Handler utilisera cet Id pour faire : SELECT * FROM trainees WHERE Id = X

// ======================================================
// DIFFÉRENCE ENTRE QUERY ET COMMAND
// ======================================================

// | Caractéristique | Query | Command |
// |-----------------|-------|---------|
// | Action | LIRE (SELECT) | ÉCRIRE (INSERT/UPDATE/DELETE) |
// | Modifie la base | NON | OUI |
// | Exemple | GetTraineeByIdQuery | CreateTraineeCommand |
// | Contenu | Paramètres de recherche | Données à sauvegarder |

// ======================================================
// UTILISATION DANS LE CONTROLLER (exemple)
// ======================================================

// Dans TraineeController.cs :
// [HttpGet("{id}")]
// public async Task<IActionResult> GetById(int id)
// {
//     // Création de la query avec l'Id reçu dans l'URL
//     var query = new GetTraineeByIdQuery(id);
//     
//     // Envoi de la query au Handler
//     var result = await _handler.Handle(query);
//     
//     return Ok(result);
// }

// ======================================================
// UTILISATION DANS LE HANDLER (exemple)
// ======================================================

// Dans GetTraineeByIdHandler.cs :
// public async Task<TraineeDetailDto> Handle(GetTraineeByIdQuery query)
// {
//     // Récupération de l'Id
//     var id = query.Id;  // 5
//     
//     // Recherche du stagiaire
//     var trainee = await _repository.GetWithPhasesAsync(id);
//     
//     // ... traitement ...
// }

// ======================================================
// EXEMPLE DE REQUÊTE COMPLÈTE
// ======================================================

// URL : GET /api/trainees/5
// 
// Dans le Controller :
//   id = 5 (vient de l'URL)
// 
// Création de la query :
//   query.Id = 5
// 
// Le Handler fait :
//   SELECT * FROM trainees WHERE Id = 5

// ======================================================
// À RETENIR
// ======================================================

// 1. GetTraineeByIdQuery contient UNIQUEMENT l'Id
// 2. C'est une QUERY (lecture seule), pas une COMMAND
// 3. Le constructeur reçoit l'Id et le stocke
// 4. L'Id vient de l'URL (GET /api/trainees/5)
// 5. Le Handler utilisera cet Id pour chercher le stagiaire


*/