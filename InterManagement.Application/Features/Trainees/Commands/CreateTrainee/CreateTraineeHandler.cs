using InterManagement.Application.Features.Trainees.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Trainees.Commands.CreateTrainee
{

    // ======================================================
    // CLASSE HANDLER POUR CRÉER UN STAGIAIRE
    // ======================================================

    // public → accessible par le Controller
    // class CreateTraineeHandler → nom du Handler
    // Un Handler = le CERVEAU qui exécute la logique de la commande
    public class CreateTraineeHandler
    {

        // ITraineeRepository → l'interface qui permet d'accéder à la base
        // _repository → le nom de la variable
        private readonly ITraineeRepository _repository;

        // ITraineeRepository repository → paramètre reçu (injection de dépendances)
        public CreateTraineeHandler(ITraineeRepository repository)
        {
            // Stocke le repository reçu dans le champ _repository
            // Le Handler pourra maintenant appeler _repository.EmailExistsAsync()
            _repository = repository;
        }


        // ==================================================
        // MÉTHODE PRINCIPALE : Handle
        // ==================================================
        
        // Task<TraineeDto> → retourne un TraineeDto de façon asynchrone
        // Handle → nom standard CQRS (exécute la commande)
        // CreateTraineeCommand command → reçoit la commande avec les données
        public async Task<TraineeDto> Handle(CreateTraineeCommand command)

        {

            // ==============================================
            // ÉTAPE 1 : VÉRIFIER QUE L'EMAIL EST UNIQUE
            // ==============================================
            
            // Appelle le repository pour vérifier si l'email existe déjà
            // command.Data.Email → récupère l'email depuis la commande
            // await → attend que la base de données réponde
            // emailExists = true → email déjà utilisé, false → email libre
            
            // Si l'email existe déjà (emailExists == true)
            // 1. Vérifier email existe déjà
            var emailExists = await _repository.EmailExistsAsync(command.Data.Email);
            if (emailExists)
                throw new TraineeAlreadyExistsException(command.Data.Email);

            // ==============================================
            // ÉTAPE 2 : CRÉER L'ENTITÉ TRAINEE
            // ==============================================
            
            // new Trainee(...) → crée un objet Trainee en mémoire
            // command.Data.FirstName → récupère le prénom depuis la commande
            // Les valeurs sont passées dans l'ordre du constructeur
            // Le constructeur de Trainee applique les validations :
            //   - Vérifie que les champs obligatoires ne sont pas vides
            //   - Vérifie que les dates sont valides
            //   - Met Status = InProgress par défaut
            //   - Met IsActive = true par défaut
            // 2. Créer l'entité
            var trainee = new Trainee(
                command.Data.FirstName,
                command.Data.LastName,
                command.Data.Email,
                command.Data.University,
                command.Data.Specialty,
                command.Data.Theme,
                command.Data.StartDate,
                command.Data.EndDate,
                TraineeStatus.InProgress
                
            );    //  "Je crée un stagiaire en mémoire pour l'envoyer à la base"
            // À ce stade : trainee existe en mémoire, Id = 0 (pas encore en base)


            // 3. Sauvegarder en base
            // Appelle le repository pour sauvegarder l'entité
            await _repository.AddAsync(trainee);


            // ==============================================
            // ÉTAPE 4 : RETOURNER LE DTO AU CLIENT
            // ==============================================
            
            // new TraineeDto { ... } → crée un DTO avec les données
            // On retourne UNIQUEMENT ce que le client doit voir
            // On ne retourne PAS : CreatedAt, UpdatedAt, IsDeleted, Phases, etc.
            // Les valeurs viennent de l'entité trainee (maintenant avec son Id)
            // 4. Retourner le DTO
            return new TraineeDto    
            {
                Id        = trainee.Id,
                FirstName = trainee.FirstName,  
                LastName  = trainee.LastName,
                Email     = trainee.Email,
                University = trainee.University,
                Specialty  = trainee.Specialty,
                Theme      = trainee.Theme,
                StartDate  = trainee.StartDate,
                EndDate    = trainee.EndDate,
                Status     = trainee.Status,
                IsActive   = trainee.IsActive   
            }; // "Je crée une réponse propre à renvoyer au client"       
        }
    }
}


















































































/*


// ======================================================
// IMPORTATIONS (USING)
// ======================================================

// Importe les DTOs (CreateTraineeDto, TraineeDto) depuis le dossier DTOs
using InterManagement.Application.Features.Trainees.DTOs;

// Importe les entités (Trainee, TraineeStatus) depuis le Domain
using InterManagement.Domain.Entities;

// Importe les exceptions personnalisées (TraineeAlreadyExistsException)
using InterManagement.Domain.Exceptions;

// Importe l'interface ITraineeRepository pour accéder à la base de données
using InterManagement.Domain.Repositories;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : Application/Features/Trainees/Commands/CreateTrainee/
namespace InterManagement.Application.Features.Trainees.Commands.CreateTrainee;

// ======================================================
// CLASSE HANDLER POUR CRÉER UN STAGIAIRE
// ======================================================

// public → accessible par le Controller
// class CreateTraineeHandler → nom du Handler
// Un Handler = le CERVEAU qui exécute la logique de la commande
public class CreateTraineeHandler
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
    // CreateTraineeHandler → nom du constructeur (identique à la classe)
    // ITraineeRepository repository → paramètre reçu (injection de dépendances)
    public CreateTraineeHandler(ITraineeRepository repository)
    {
        // Stocke le repository reçu dans le champ _repository
        // Le Handler pourra maintenant appeler _repository.EmailExistsAsync()
        _repository = repository;
    }

    // ==================================================
    // MÉTHODE PRINCIPALE : Handle
    // ==================================================
    
    // public → accessible par le Controller
    // async → méthode asynchrone (ne bloque pas pendant l'accès base)
    // Task<TraineeDto> → retourne un TraineeDto de façon asynchrone
    // Handle → nom standard CQRS (exécute la commande)
    // CreateTraineeCommand command → reçoit la commande avec les données
    public async Task<TraineeDto> Handle(CreateTraineeCommand command)
    {
        // ==============================================
        // ÉTAPE 1 : VÉRIFIER QUE L'EMAIL EST UNIQUE
        // ==============================================
        
        // Appelle le repository pour vérifier si l'email existe déjà
        // command.Data.Email → récupère l'email depuis la commande
        // await → attend que la base de données réponde
        // emailExists = true → email déjà utilisé, false → email libre
        var emailExists = await _repository.EmailExistsAsync(command.Data.Email);
        
        // Si l'email existe déjà (emailExists == true)
        if (emailExists)
            // Lance une exception personnalisée avec l'email en message
            // L'exécution s'arrête ici, rien après n'est exécuté
            throw new TraineeAlreadyExistsException(command.Data.Email);

        // ==============================================
        // ÉTAPE 2 : CRÉER L'ENTITÉ TRAINEE
        // ==============================================
        
        // new Trainee(...) → crée un objet Trainee en mémoire
        // command.Data.FirstName → récupère le prénom depuis la commande
        // Les valeurs sont passées dans l'ordre du constructeur
        // Le constructeur de Trainee applique les validations :
        //   - Vérifie que les champs obligatoires ne sont pas vides
        //   - Vérifie que les dates sont valides
        //   - Met Status = InProgress par défaut
        //   - Met IsActive = true par défaut
        var trainee = new Trainee(
            command.Data.FirstName,   // "Moussa"
            command.Data.LastName,    // "Diallo"
            command.Data.Email,       // "moussa@email.com"
            command.Data.University,  // "ESMT"
            command.Data.Specialty,   // "Informatique"
            command.Data.Theme,       // "Développement Web"
            command.Data.StartDate,   // "2025-01-06"
            command.Data.EndDate      // "2025-04-27"
        );
        // À ce stade : trainee existe en mémoire, Id = 0 (pas encore en base)

        // ==============================================
        // ÉTAPE 3 : SAUVEGARDER EN BASE DE DONNÉES
        // ==============================================
        
        // Appelle le repository pour sauvegarder l'entité
        // AddAsync(trainee) :
        //   - Ajoute trainee en mémoire (INSERT préparé)
        //   - Exécute SaveChangesAsync() (INSERT réel en SQL)
        //   - SQL généré : INSERT INTO trainees VALUES (...)
        //   - La base génère un Id (auto-incrément)
        //   - L'Id est automatiquement mis dans trainee.Id
        await _repository.AddAsync(trainee);
        // À ce stade : trainee.Id = 5 (généré par la base)

        // ==============================================
        // ÉTAPE 4 : RETOURNER LE DTO AU CLIENT
        // ==============================================
        
        // new TraineeDto { ... } → crée un DTO avec les données
        // On retourne UNIQUEMENT ce que le client doit voir
        // On ne retourne PAS : CreatedAt, UpdatedAt, IsDeleted, Phases, etc.
        // Les valeurs viennent de l'entité trainee (maintenant avec son Id)
        return new TraineeDto
        {
            Id        = trainee.Id,           // 5 (généré par la base)
            FirstName = trainee.FirstName,    // "Moussa"
            LastName  = trainee.LastName,     // "Diallo"
            Email     = trainee.Email,        // "moussa@email.com"
            University = trainee.University,  // "ESMT"
            Specialty  = trainee.Specialty,   // "Informatique"
            Theme      = trainee.Theme,       // "Développement Web"
            StartDate  = trainee.StartDate,   // "2025-01-06"
            EndDate    = trainee.EndDate,     // "2025-04-27"
            Status     = trainee.Status,      // InProgress (valeur par défaut)
            IsActive   = trainee.IsActive     // true (valeur par défaut)
        };
    }
}

// ======================================================
// RÉSUMÉ DU FLUX
// ======================================================

// 1. Le Controller reçoit CreateTraineeDto
// 2. Le Controller crée CreateTraineeCommand avec le DTO
// 3. Le Controller appelle Handle(command)
// 
// 4. Le Handler :
//    a) Vérifie que l'email n'existe pas déjà
//    b) Crée l'entité Trainee avec les données
//    c) Sauvegarde en base (l'Id est généré)
//    d) Retourne un TraineeDto avec l'Id et les données
// 
// 5. Le Controller reçoit le TraineeDto
// 6. Le Controller retourne Ok(TraineeDto) au client

// ======================================================
// CE QUE TU DOIS DIRE À TON MENTOR
// ======================================================

// "Le Handler est le cerveau de l'opération CreateTrainee.
// 
// Il reçoit une Command qui contient les données du formulaire.
// 
// Étape 1 : Il vérifie que l'email n'est pas déjà utilisé en interrogeant la base.
// 
// Étape 2 : Il crée l'entité Trainee. Le constructeur de Trainee applique 
//           les validations (champs obligatoires, dates valides) et met 
//           les valeurs par défaut (Status = InProgress, IsActive = true).
// 
// Étape 3 : Il sauvegarde l'entité en base via le repository. La base génère 
//           un Id automatiquement et le met dans trainee.Id.
// 
// Étape 4 : Il retourne un TraineeDto avec l'Id généré et toutes les informations.
// 
// Le Handler ne sait PAS comment la base fonctionne (SQL, PostgreSQL, etc.).
// Il utilise l'interface ITraineeRepository qui est implémentée dans Infrastructure." 



*/