// > **`UpdateTraineeDto`** : utilisé pour la modification. Le client peut modifier le Status, contrairement à la création. L'Id est dans l'URL, pas dans le body.

/*
using InterManagement.Domain.Entities;

namespace InterManagement.Application.Features.Trainees.DTOs
{
    public class UpdateTraineeDto
    {
        // ── Infos personnelles ────────────────
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // ── Infos stage ───────────────────────
        public string University { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        // ── Statut ────────────────────────────
        public TraineeStatus Status { get; set; }
    }
}

*/



// ======================================================
// IMPORTATION (USING)
// ======================================================

// Importe les entités du Domain (TraineeStatus)
// On a besoin de TraineeStatus pour le type de la propriété Status
using InterManagement.Domain.Entities;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms où se trouve ce fichier
// Correspond au dossier : Application/Features/Trainees/DTOs/
namespace InterManagement.Application.Features.Trainees.DTOs;

// ======================================================
// CLASSE DTO POUR LA MODIFICATION D'UN STAGIAIRE
// ======================================================

// public → accessible par tous (notamment le Controller)
// class UpdateTraineeDto → nom explicite : ce DTO sert à MODIFIER un stagiaire
// Ce DTO est utilisé UNIQUEMENT pour la requête PUT /api/trainees/{id}
// Il contient les données que le client PEUT envoyer pour modifier un stagiaire
public class UpdateTraineeDto
{
    // ==================================================
    // PROPRIÉTÉS
    // ==================================================
    // Chaque propriété = une donnée MODIFIABLE
    // { get; set; } = on peut lire ET écrire
    // = string.Empty = valeur par défaut = chaîne vide (pas null)
    
    // ──────────────────────────────────────────────
    // IDENTITÉ (MODIFIABLE)
    // ──────────────────────────────────────────────
    
    // FirstName = prénom du stagiaire
    // Exemple : "Moussa" → peut être modifié en "Moussa Ahmed"
    // Optionnel dans la requête (on peut envoyer juste ce qu'on veut modifier)
    public string FirstName { get; set; } = string.Empty;
    
    // LastName = nom du stagiaire
    // Exemple : "Diallo" → peut être modifié en "Diallo Thiam"
    public string LastName { get; set; } = string.Empty;
    
    // Email = adresse email du stagiaire
    // Exemple : "moussa@email.com" → peut être modifié
    // Attention : doit rester unique après modification
    public string Email { get; set; } = string.Empty;
    
    // ──────────────────────────────────────────────
    // INFORMATIONS ACADÉMIQUES (MODIFIABLES)
    // ──────────────────────────────────────────────
    
    // University = université ou école du stagiaire
    // Exemple : "ESMT" → peut être modifié en "UCAD"
    public string University { get; set; } = string.Empty;
    
    // Specialty = spécialité/filière d'étude
    // Exemple : "Informatique" → peut être modifié en "Réseaux"
    public string Specialty { get; set; } = string.Empty;
    
    // Theme = thème du stage
    // Exemple : "Développement Web" → peut être modifié en "IA"
    public string Theme { get; set; } = string.Empty;
    
    // ──────────────────────────────────────────────
    // DATES (MODIFIABLES)
    // ──────────────────────────────────────────────
    
    // StartDate = date de début du stage
    // Type DateOnly → seulement la date (pas l'heure)
    // Exemple : "2025-01-06" → peut être modifié
    public DateOnly StartDate { get; set; }
    
    // EndDate = date de fin du stage
    // Type DateOnly → seulement la date (pas l'heure)
    // Exemple : "2025-04-27" → peut être modifié
    public DateOnly EndDate { get; set; }
    
    // ──────────────────────────────────────────────
    // STATUT (MODIFIABLE)
    // ──────────────────────────────────────────────
    
    // Status = statut du stage
    // Type = TraineeStatus (enum du Domain)
    // Valeurs possibles : Pending, InProgress, Completed, Suspended
    // Exemple : un stagiaire qui a terminé → Status = Completed
    // C'est l'admin qui change ce statut manuellement
    public TraineeStatus Status { get; set; }
}

// ======================================================
// CE QUE LE CLIENT PEUT ENVOYER (JSON)
// ======================================================

// Requête PUT /api/trainees/5
// Body de la requête (MODIFICATION PARTIELLE POSSIBLE) :
//
// Cas 1 : On modifie seulement le prénom et le nom
// {
//   "firstName": "Moussa Ahmed",
//   "lastName": "Diallo Thiam"
//   // Les autres champs ne sont pas envoyés
// }
//
// Cas 2 : On modifie le statut (stagiaire qui a terminé)
// {
//   "status": 2   // Completed
// }
//
// Cas 3 : On modifie plusieurs champs
// {
//   "firstName": "Moussa Ahmed",
//   "email": "nouveau@email.com",
//   "university": "UCAD"
// }

// ======================================================
// DIFFÉRENCE ENTRE CreateTraineeDto ET UpdateTraineeDto
// ======================================================

// CreateTraineeDto (CRÉATION) :
// - Tous les champs sont OBLIGATOIRES
// - Pas de Status (valeur par défaut InProgress)
// - Utilisé en POST

// UpdateTraineeDto (MODIFICATION) :
// - Tous les champs sont OPTIONNELS
// - On peut modifier le Status
// - Utilisé en PUT
// - L'Id est dans l'URL, pas dans le body

// ======================================================
// CE QUE CE DTO NE CONTIENT PAS (VOLONTAIREMENT)
// ======================================================

// - Id → L'Id est dans l'URL de la requête (PUT /api/trainees/{id})
// - IsActive → Modification du compte (désactiver un utilisateur)
//   Pourrait être ajouté plus tard dans un DTO séparé
// - CreatedAt → Ne doit jamais être modifié
// - UpdatedAt → Rempli automatiquement par le Repository
// - IsDeleted → Ne doit jamais être modifié directement (soft delete via DELETE)

// ======================================================
// NOTE SUR LES MODIFICATIONS PARTIELLES
// ======================================================

// En C# avec ASP.NET Core, quand le client envoie un JSON avec seulement
// certains champs, les champs non envoyés gardent leur valeur par défaut
// (string.Empty pour les strings, null pour les types nullables)

// Pour gérer correctement les modifications partielles, le Handler doit :
// 1. Récupérer l'entité existante depuis la base
// 2. Ne modifier que les champs qui ont changé
// 3. Ne pas écraser les champs non envoyés par des valeurs vides