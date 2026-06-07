using InterManagement.Application.Features.Trainees.Commands.CreateTrainee;
using InterManagement.Application.Features.Trainees.Commands.UpdateTrainee;
using InterManagement.Application.Features.Trainees.Commands.DeleteTrainee;
using InterManagement.Application.Features.Trainees.Queries.GetTrainees;
using InterManagement.Application.Features.Trainees.Queries.GetTraineeById;
using Microsoft.Extensions.DependencyInjection;

namespace InterManagement.Application
{
    // ======================================================
    // CLASSE STATIQUE D'INJECTION DE DÉPENDANCES POUR LA COUCHE APPLICATION
    // ======================================================
    public static class DependencyInjection
    {
        // ==================================================
        // MÉTHODE D'EXTENSION AddApplication
        // ==================================================
        // IServiceCollection AddApplication → retourne IServiceCollection pour permettre l'enchaînement
        public static IServiceCollection AddApplication(
            this IServiceCollection services) // → méthode d'extension qui s'ajoute à IServiceCollection Cela permet d'appeler services.AddApplication() dans Program.cs
        {

            // ==================================================
            // ENREGISTREMENT DES HANDLERS (AVEC AddScoped)
            // ==================================================
            
            // services.AddScoped<T>() → enregistre un service avec une durée de vie SCOPED
            // AddScoped = crée une NOUVELLE INSTANCE par REQUÊTE HTTP 
            // C'est parfait pour les Handlers car ils n'ont pas d'état (stateless)

            // Enregistrement du Handler pour créer un stagiaire
            // Chaque requête POST /api/trainees créera une nouvelle instance de CreateTraineeHandler            
            services.AddScoped<CreateTraineeHandler>();

            services.AddScoped<UpdateTraineeHandler>();

            services.AddScoped<DeleteTraineeHandler>();

            services.AddScoped<GetTraineesHandler>();

            services.AddScoped<GetTraineeByIdHandler>();

            return services;  //    Retourne services pour permettre l'enchaînement d'appels

        }
    }
}









































/*

// ======================================================
// IMPORTATIONS DES HANDLERS (USING)
// ======================================================

// Importe le Handler pour créer un stagiaire
// CreateTraineeHandler contient la logique de création (validation email, création entité, sauvegarde)
using InterManagement.Application.Features.Trainees.Commands.CreateTrainee;

// Importe le Handler pour modifier un stagiaire
// UpdateTraineeHandler contient la logique de modification (vérification existence, modification champs)
using InterManagement.Application.Features.Trainees.Commands.UpdateTrainee;

// Importe le Handler pour supprimer un stagiaire
// DeleteTraineeHandler contient la logique de suppression (soft delete)
using InterManagement.Application.Features.Trainees.Commands.DeleteTrainee;

// Importe le Handler pour récupérer la liste des stagiaires
// GetTraineesHandler contient la logique de lecture de la liste (avec filtre optionnel)
using InterManagement.Application.Features.Trainees.Queries.GetTrainees;

// Importe le Handler pour récupérer le détail d'un stagiaire
// GetTraineeByIdHandler contient la logique de lecture du détail (avec relations)
using InterManagement.Application.Features.Trainees.Queries.GetTraineeById;

// Importe le système d'injection de dépendances de Microsoft
// Permet d'enregistrer les services dans le conteneur DI
using Microsoft.Extensions.DependencyInjection;

// ======================================================
// NAMESPACE
// ======================================================

// Déclare l'espace de noms (dossier) où se trouve ce fichier
// Correspond au chemin : InterManagement.Application/
namespace InterManagement.Application;

// ======================================================
// CLASSE STATIQUE D'INJECTION DE DÉPENDANCES POUR LA COUCHE APPLICATION
// ======================================================

// public → accessible par les autres projets (notamment le Server)
// static → ne peut pas être instanciée, contient uniquement des méthodes statiques
// class DependencyInjection → nom de la classe
public static class DependencyInjection
{
    // ==================================================
    // MÉTHODE D'EXTENSION AddApplication
    // ==================================================
    
    // public static → accessible sans instance de classe
    // this IServiceCollection services → méthode d'extension qui s'ajoute à IServiceCollection
    //   Cela permet d'appeler services.AddApplication() dans Program.cs
    // IServiceCollection AddApplication → retourne IServiceCollection pour permettre l'enchaînement
    // this IServiceCollection services → paramètre : le conteneur DI auquel on ajoute nos services
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // ==================================================
        // ENREGISTREMENT DES HANDLERS (AVEC AddScoped)
        // ==================================================
        
        // services.AddScoped<T>() → enregistre un service avec une durée de vie SCOPED
        // AddScoped = crée une NOUVELLE INSTANCE par REQUÊTE HTTP
        // C'est parfait pour les Handlers car ils n'ont pas d'état (stateless)
        
        // Enregistrement du Handler pour créer un stagiaire
        // Chaque requête POST /api/trainees créera une nouvelle instance de CreateTraineeHandler
        services.AddScoped<CreateTraineeHandler>();
        
        // Enregistrement du Handler pour modifier un stagiaire
        // Chaque requête PUT /api/trainees/{id} créera une nouvelle instance de UpdateTraineeHandler
        services.AddScoped<UpdateTraineeHandler>();
        
        // Enregistrement du Handler pour supprimer un stagiaire
        // Chaque requête DELETE /api/trainees/{id} créera une nouvelle instance de DeleteTraineeHandler
        services.AddScoped<DeleteTraineeHandler>();
        
        // Enregistrement du Handler pour récupérer la liste des stagiaires
        // Chaque requête GET /api/trainees créera une nouvelle instance de GetTraineesHandler
        services.AddScoped<GetTraineesHandler>();
        
        // Enregistrement du Handler pour récupérer le détail d'un stagiaire
        // Chaque requête GET /api/trainees/{id} créera une nouvelle instance de GetTraineeByIdHandler
        services.AddScoped<GetTraineeByIdHandler>();

        // ==================================================
        // RETOUR DES SERVICES
        // ==================================================
        
        // Retourne services pour permettre l'enchaînement d'appels
        // Exemple d'utilisation dans Program.cs :
        // services.AddApplication().AddInfrastructure(configuration).AddControllers()
        return services;
    }
}

// ======================================================
// EXPLICATION DES DURÉES DE VIE
// ======================================================

// AddTransient : Nouvelle instance À CHAQUE DEMANDE (même dans la même requête)
//   Exemple : Si un service est demandé 3 fois dans la même requête → 3 instances différentes
//   Utiliser pour : Services très légers sans état

// AddScoped : Une instance par REQUÊTE HTTP
//   Exemple : Si un service est demandé 3 fois dans la même requête → 1 instance réutilisée
//   Utiliser pour : Handlers, Repositories, DbContext (RECOMMANDÉ)

// AddSingleton : Une instance pour TOUTE LA VIE DE L'APPLICATION
//   Exemple : 1 seule instance créée au démarrage, réutilisée pour TOUTES les requêtes
//   Utiliser pour : Logging, Configuration, Cache

// ======================================================
// UTILISATION DANS Program.cs (PROJET SERVER)
// ======================================================

// var builder = WebApplication.CreateBuilder(args);
// 
// // Ajoute les services de la couche Application
// builder.Services.AddApplication();
// 
// // Ajoute les services de la couche Infrastructure
// builder.Services.AddInfrastructure(builder.Configuration);
// 
// // Ajoute les Controllers
// builder.Services.AddControllers();
// 
// var app = builder.Build();
// app.Run();

// ======================================================
// CE QUE FAIT CETTE CLASSE
// ======================================================

// 1. Elle enregistre TOUS les Handlers de la couche Application
// 2. Chaque Handler est enregistré avec AddScoped (1 instance par requête)
// 3. Les Handlers pourront être injectés dans les Controllers
// 4. Quand le Controller demande CreateTraineeHandler, le conteneur DI le fournit

// ======================================================
// À RETENIR
// ======================================================

// 1. AddScoped = durée de vie par requête HTTP (RECOMMANDÉ pour les Handlers)
// 2. Chaque Handler doit être enregistré pour être injectable
// 3. La méthode AddApplication est une méthode d'extension (this IServiceCollection)
// 4. On retourne IServiceCollection pour permettre le chaînage (Fluent API)
// 5. Cette configuration centralise tous les services de la couche Application


*/
