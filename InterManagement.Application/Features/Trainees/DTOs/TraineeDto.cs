//**`TraineeDto`** : utilisé pour la liste. Il contient les informations de base mais PAS les relations (Phases, Evaluations) pour des raisons de performance.


/*using InterManagement.Domain.Entities;

namespace InterManagement.Application.Features.Trainees.DTOs
{
    public class TraineeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TraineeStatus Status { get; set; }  
        public bool IsActive { get; set; }
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
// CLASSE DTO (DATA TRANSFER OBJECT)
// ======================================================

// public → accessible par tous (Server, Application, Tests)
// class TraineeDto → nom de la classe
// DTO = Objet qui VOYAGE entre le serveur et le client
// Ce n'est PAS une entité, c'est juste un conteneur de données
public class TraineeDto
{
    // ==================================================
    // PROPRIÉTÉS
    // ==================================================
    // Chaque propriété = UNE donnée que le client va recevoir
    // { get; set; } = on peut lire ET écrire
    // = string.Empty = valeur par défaut = chaîne vide (pas null)
    
    // ──────────────────────────────────────────────
    // IDENTIFIANT
    // ──────────────────────────────────────────────
    // Id = l'identifiant unique du stagiaire
    // Généré par la base de données au moment de l'insertion
    // Le client a besoin de l'Id pour :
    //   - Modifier le stagiaire (PUT /api/trainees/{id})
    //   - Supprimer le stagiaire (DELETE /api/trainees/{id})
    //   - Afficher le détail (GET /api/trainees/{id})
    public int Id { get; set; }
    
    // ──────────────────────────────────────────────
    // IDENTITÉ
    // ──────────────────────────────────────────────
    
    // FirstName = prénom du stagiaire
    // Exemple : "Moussa"
    public string FirstName { get; set; } = string.Empty;
    
    // LastName = nom du stagiaire
    // Exemple : "Diallo"
    public string LastName { get; set; } = string.Empty;
    
    // Email = adresse email du stagiaire
    // Exemple : "moussa@email.com"
    // Utilisé pour la connexion et les communications
    public string Email { get; set; } = string.Empty;
    
    // ──────────────────────────────────────────────
    // INFORMATIONS ACADÉMIQUES
    // ──────────────────────────────────────────────
    
    // University = université ou école du stagiaire
    // Exemple : "ESMT" ou "UCAD"
    public string University { get; set; } = string.Empty;
    
    // Specialty = spécialité/filière d'étude
    // Exemple : "Informatique", "Réseaux", "Génie Civil"
    public string Specialty { get; set; } = string.Empty;
    
    // Theme = thème du stage
    // Exemple : "Développement Web", "Administration Système"
    public string Theme { get; set; } = string.Empty;
    
    // ──────────────────────────────────────────────
    // DATES
    // ──────────────────────────────────────────────
    
    // StartDate = date de début du stage
    // Type DateOnly → seulement la date (pas l'heure)
    // Exemple : 2025-01-06
    public DateOnly StartDate { get; set; }
    
    // EndDate = date de fin du stage
    // Type DateOnly → seulement la date (pas l'heure)
    // Exemple : 2025-04-27
    public DateOnly EndDate { get; set; }
    
    // ──────────────────────────────────────────────
    // STATUTS
    // ──────────────────────────────────────────────
    
    // Status = statut du stage
    // Type = TraineeStatus (enum du Domain)
    // Valeurs possibles : Pending, InProgress, Completed, Suspended
    // InProgress = "En cours" pour un stage actif
    public TraineeStatus Status { get; set; }
    
    // IsActive = statut du compte utilisateur
    // true = compte actif (peut se connecter)
    // false = compte désactivé (ne peut pas se connecter)
    // Différent de Status (qui concerne le stage)
    // Un stagiaire peut avoir un stage Completed mais un compte IsActive = true
    public bool IsActive { get; set; }
}

// ======================================================
// CE QUE CE DTO CONTIENT
// ======================================================

// Ce DTO contient TOUTES les informations que le client
// peut voir sur un stagiaire dans la liste ou le détail

// DONNÉES RETOURNÉES AU CLIENT (JSON) :
// {
//   "id": 5,
//   "firstName": "Moussa",
//   "lastName": "Diallo",
//   "email": "moussa@email.com",
//   "university": "ESMT",
//   "specialty": "Informatique",
//   "theme": "Développement Web",
//   "startDate": "2025-01-06",
//   "endDate": "2025-04-27",
//   "status": 1,
//   "isActive": true
// }

// ======================================================
// CE QUE CE DTO NE CONTIENT PAS (VOLONTAIREMENT)
// ======================================================

// - CreatedAt (date de création en base) → interne
// - UpdatedAt (date de modification) → interne
// - IsDeleted (soft delete) → interne
// - Phases (collection des phases) → trop lourd pour la liste
// - User (relation) → évite les boucles infinies
// - Assignments (relations) → évite les boucles infinies
// - Evaluations (relations) → évite les boucles infinies

// ======================================================
// DIFFÉRENCE AVEC L'ENTITÉ TRAINEE (DOMAIN)
// ======================================================

// ENTITÉ Trainee (dans Domain/Entities/Trainees.cs) :
// - Contient TOUTES les propriétés (y compris CreatedAt, UpdatedAt, IsDeleted)
// - Contient les relations (Phases, Assignments, Evaluations, Feedbacks, Files)
// - Utilisée par le Repository pour interagir avec la base
// - Ne voyage JAMAIS vers le client

// DTO TraineeDto (dans Application/Features/DTOs) :
// - Contient SEULEMENT ce que le client doit voir
// - Ne contient pas les relations
// - Ne contient pas les propriétés techniques (IsDeleted, CreatedAt)
// - Voyage entre le serveur et le client

// ======================================================
// POURQUOI ON RETOURNE UN DTO (PAS L'ENTITÉ) ?
// ======================================================

// 1. SÉCURITÉ : On n'expose pas IsDeleted, CreatedAt, UpdatedAt
// 2. PERFORMANCE : On n'envoie pas les relations (Phases, etc.)
// 3. SÉRIALISATION : Évite les boucles infinies (User → Trainee → User)
// 4. CONTRAT : Le client sait EXACTEMENT ce qu'il va recevoir
