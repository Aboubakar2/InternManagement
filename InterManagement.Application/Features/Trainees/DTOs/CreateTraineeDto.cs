//**`CreateTraineeDto`** : utilisé pour la création. Le client envoie les données sans l'Id (c'est la base qui le génère) et sans le Status (valeur par défaut InProgress).


namespace InterManagement.Application.Features.Trainees.DTOs
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






































// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms où se trouve ce fichier
// Correspond au dossier : Application/Features/Trainees/DTOs/
//namespace InterManagement.Application.Features.Trainees.DTOs;

// ======================================================
// CLASSE DTO POUR LA CRÉATION D'UN STAGIAIRE
// ======================================================

// public → accessible par tous (notamment le Controller)
// class CreateTraineeDto → nom explicite : ce DTO sert à CRÉER un stagiaire
// Ce DTO est utilisé UNIQUEMENT pour la requête POST /api/trainees
// Il contient les données que le client DOIT envoyer pour créer un stagiaire
//public class CreateTraineeDto
//{
    // ==================================================
    // PROPRIÉTÉS
    // ==================================================
    // Chaque propriété = une donnée REQUISE pour créer un stagiaire
    // { get; set; } = on peut lire ET écrire
    // = string.Empty = valeur par défaut = chaîne vide (pas null)
    
    // ──────────────────────────────────────────────
    // IDENTITÉ (OBLIGATOIRE)
    // ──────────────────────────────────────────────
    
    // FirstName = prénom du stagiaire
    // Exemple : "Moussa"
    // Validation dans le Handler : ne peut pas être vide ou null
    //public string FirstName { get; set; } = string.Empty;
    
    // LastName = nom du stagiaire
    // Exemple : "Diallo"
    // Validation dans le Handler : ne peut pas être vide ou null
    //public string LastName { get; set; } = string.Empty;
    
    // Email = adresse email du stagiaire
    // Exemple : "moussa@email.com"
    // Validation dans le Handler : 
    //   - ne peut pas être vide ou null
    //   - doit être unique (ne pas exister déjà en base)
    //public string Email { get; set; } = string.Empty;
    
    // ──────────────────────────────────────────────
    // INFORMATIONS ACADÉMIQUES (OBLIGATOIRES)
    // ──────────────────────────────────────────────
    
    // University = université ou école du stagiaire
    // Exemple : "ESMT" ou "UCAD"
    // Validation dans le Handler : ne peut pas être vide ou null
    //public string University { get; set; } = string.Empty;
    
    // Specialty = spécialité/filière d'étude
    // Exemple : "Informatique", "Réseaux", "Génie Civil"
    // Validation dans le Handler : ne peut pas être vide ou null
    //public string Specialty { get; set; } = string.Empty;
    
    // Theme = thème du stage
    // Exemple : "Développement Web", "Administration Système"
    // Validation dans le Handler : ne peut pas être vide ou null
    //public string Theme { get; set; } = string.Empty;
    
    // ──────────────────────────────────────────────
    // DATES (OBLIGATOIRES)
    // ──────────────────────────────────────────────
    
    // StartDate = date de début du stage
    // Type DateOnly → seulement la date (pas l'heure)
    // Exemple : "2025-01-06" (format JSON)
    // Validation dans le Handler : 
    //   - ne peut pas être dans le passé
    //   - doit être avant EndDate
    //public DateOnly StartDate { get; set; }
    
    // EndDate = date de fin du stage
    // Type DateOnly → seulement la date (pas l'heure)
    // Exemple : "2025-04-27" (format JSON)
    // Validation dans le Handler : doit être après StartDate
    //public DateOnly EndDate { get; set; }
//}









































// ======================================================
// CE QUE LE CLIENT DOIT ENVOYER (JSON)
// ======================================================

// Requête POST /api/trainees
// Body de la requête :
// {
//   "firstName": "Moussa",
//   "lastName": "Diallo",
//   "email": "moussa@email.com",
//   "university": "ESMT",
//   "specialty": "Informatique",
//   "theme": "Développement Web",
//   "startDate": "2025-01-06",
//   "endDate": "2025-04-27"
// }

// ======================================================
// CE QUE CE DTO NE CONTIENT PAS (VOLONTAIREMENT)
// ======================================================

// - Id → La base de données le générera automatiquement
// - Status → Valeur par défaut "InProgress" dans le constructeur de Trainee
// - IsActive → Valeur par défaut "true" dans le constructeur de Trainee
// - CreatedAt → Rempli automatiquement par le Repository
// - UpdatedAt → Rempli automatiquement par le Repository
// - IsDeleted → Rempli automatiquement par le Repository (false)

// ======================================================
// DIFFÉRENCE ENTRE CreateTraineeDto ET TraineeDto
// ======================================================

// CreateTraineeDto (CE QUI ENTRE) :
// - Utilisé pour la REQUÊTE (client → serveur)
// - Ne contient PAS Id (la base le génère)
// - Ne contient PAS Status (valeur par défaut)
// - Ne contient PAS IsActive (valeur par défaut)

// TraineeDto (CE QUI SORT) :
// - Utilisé pour la RÉPONSE (serveur → client)
// - Contient Id (généré par la base)
// - Contient Status (défini par défaut)
// - Contient IsActive (défini par défaut)

// ======================================================
// POURQUOI DEUX DTOS DIFFÉRENTS ?
// ======================================================

// 1. SÉCURITÉ : Le client ne peut PAS envoyer d'Id
//    (il ne peut pas choisir l'Id du stagiaire)

// 2. CLARTÉ : Chaque DTO a un rôle précis
//    - CreateTraineeDto : ce qu'on RECOIT pour créer
//    - TraineeDto : ce qu'on RENVOIE après création

// 3. ÉVOLUTIVITÉ : On peut changer CreateTraineeDto
//    sans affecter TraineeDto (et inversement)