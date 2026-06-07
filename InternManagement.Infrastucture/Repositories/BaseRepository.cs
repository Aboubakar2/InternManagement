using System.Linq;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using InternManagement.Infrastructure.Data;


namespace InterManagement.Infrastucture.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity); // On demande la suppression physique
            await _context.SaveChangesAsync(); // Le DbContext intercepte et transforme en Soft Delete
        }
    }

   
}

/*

// ======================================================
// IMPORTATIONS (USING)
// ======================================================

using System.Linq;           // Importe les méthodes LINQ (Where, Select, etc.) - pas utilisé directement ici mais utile pour les classes filles
using InterManagement.Domain.Entities;   // Importe BaseModel (classe mère de toutes les entités)
using InterManagement.Domain.Repositories; // Importe IBaseRepository<T> (l'interface que cette classe implémente)
using Microsoft.EntityFrameworkCore;      // Importe EF Core : DbSet, SaveChangesAsync, etc.
using InternManagement.Infrastructure.Data; // Importe AppDbContext (le contexte de base de données)

// ======================================================
// NAMESPACE
// ======================================================
// Déclare l'espace de noms où se trouve cette classe
// Note : il y a une faute d'orthographe : "Infrastucture" au lieu de "Infrastructure"
namespace InterManagement.Infrastucture.Repositories;

// ======================================================
// DÉCLARATION DE LA CLASSE
// ======================================================
// BaseRepository<T> : classe générique qui fonctionne avec n'importe quel type T
// where T : BaseModel → T doit être une classe qui hérite de BaseModel (Trainee, Mentor, Phase, etc.)
// : IBaseRepository<T> → cette classe implémente l'interface IBaseRepository<T>
public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    // ======================================================
    // CHAMPS (VARIABLES DE CLASSE)
    // ======================================================
    
    // protected → accessible par cette classe ET les classes qui en héritent (TraineeRepository, etc.)
    // readonly → une fois assignée dans le constructeur, on ne peut plus la modifier
    // AppDbContext _context → le contexte de base de données (pont entre C# et SQL)
    protected readonly AppDbContext _context;
    
    // protected readonly DbSet<T> _dbSet → représente la table en base pour l'entité T
    // DbSet<T> = l'ensemble des enregistrements de type T dans la base
    // Exemple : si T = Trainee, _dbSet = la table "trainees"
    protected readonly DbSet<T> _dbSet;

    // ======================================================
    // CONSTRUCTEUR
    // ======================================================
    // S'appelle quand on crée une instance de BaseRepository<T>
    // Reçoit AppDbContext en paramètre (injection de dépendances)
    public BaseRepository(AppDbContext context)
    {
        // Stocke le contexte reçu dans le champ _context
        _context = context;
        
        // context.Set<T>() = récupère le DbSet correspondant au type T
        // Exemple : si T = Trainee, context.Set<Trainee>() retourne _context.Trainees
        _dbSet = context.Set<T>();
    }

    // ======================================================
    // MÉTHODE : GetByIdAsync
    // ======================================================
    // virtual → peut être redéfinie (override) dans une classe fille (ex: TraineeRepository)
    // async Task<T?> → méthode asynchrone qui retourne un T ou null
    // int id → l'identifiant de l'enregistrement recherché
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        // FindAsync(id) = cherche un enregistrement par sa clé primaire (Id)
        // Plus performant que FirstOrDefaultAsync pour la recherche par Id
        // Retourne null si aucun enregistrement trouvé
        return await _dbSet.FindAsync(id);
    }

    // ======================================================
    // MÉTHODE : GetAllAsync
    // ======================================================
    // Retourne TOUS les enregistrements de la table
    // Task<IEnumerable<T>> → retourne une liste (IEnumerable) de T de façon asynchrone
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        // ToListAsync() = exécute la requête et convertit les résultats en liste
        // SQL généré : SELECT * FROM [table_T] WHERE IsDeleted = 0 (grâce au HasQueryFilter)
        return await _dbSet.ToListAsync();
    }

    // ======================================================
    // MÉTHODE : AddAsync
    // ======================================================
    // Ajoute un nouvel enregistrement dans la base
    // Task<T> → retourne l'entité avec son Id généré par la base
    // T entity → l'objet à ajouter (sans Id, la base le génère)
    public virtual async Task<T> AddAsync(T entity)
    {
        // AddAsync(entity) = marque l'entité comme "à ajouter" (INSERT)
        // Ne fait pas encore l'INSERT, juste prépare
        await _dbSet.AddAsync(entity);
        
        // SaveChangesAsync() = ENVOIE TOUTES les modifications à la base de données
        // Exécute l'INSERT et récupère l'Id généré automatiquement
        // Met à jour entity.Id avec la valeur générée
        await _context.SaveChangesAsync();
        
        // Retourne l'entité (maintenant avec son Id)
        return entity;
    }

    // ======================================================
    // MÉTHODE : UpdateAsync
    // ======================================================
    // Modifie un enregistrement existant
    // Task → ne retourne rien (pas besoin, le client a déjà l'entité)
    // T entity → l'objet modifié
    public virtual async Task UpdateAsync(T entity)
    {
        // Update(entity) = marque l'entité comme "à modifier" (UPDATE)
        // EF Core détectera automatiquement quelles propriétés ont changé
        _dbSet.Update(entity);
        
        // SaveChangesAsync() = exécute l'UPDATE en base
        // SQL généré : UPDATE [table_T] SET ... WHERE Id = X
        await _context.SaveChangesAsync();
    }

    // ======================================================
    // MÉTHODE : DeleteAsync (SUPPRESSION PHYSIQUE → SERA TRANSFORMÉE EN SOFT DELETE)
    // ======================================================
    // Supprime un enregistrement (apparemment supprimer physiquement)
    // MAIS : le DbContext va transformer cette suppression physique en soft delete
    // grâce à la configuration dans AppDbContext
    // Task → ne retourne rien
    // int id → l'identifiant de l'enregistrement à supprimer
    public virtual async Task DeleteAsync(int id)
    {
        // 1. Récupère l'entité par son Id
        // Appelle GetByIdAsync (qui est virtuelle, donc peut être redéfinie)
        var entity = await GetByIdAsync(id);
        
        // 2. Vérifie que l'entité existe
        // Si entity == null, on ne fait rien (la méthode se termine silencieusement)
        if (entity != null)
        {
            // 3. Demande la suppression PHYSIQUE de l'entité
            // Normalement, Remove(entity) générerait : DELETE FROM [table_T] WHERE Id = X
            _dbSet.Remove(entity);
            
            // 4. Sauvegarde les changements
            // GRÂCE À LA CONFIGURATION DANS AppDbContext
            // Cette suppression PHYSIQUE va être INTERCEPTÉE et transformée en SOFT DELETE
            // Le HasQueryFilter(t => !t.IsDeleted) dans AppDbContext + le mécanisme EF Core
            // transforme automatiquement DELETE en UPDATE IsDeleted = 1
            await _context.SaveChangesAsync();
            
            // SQL RÉEL EXÉCUTÉ (soft delete) :
            // UPDATE [table_T] SET IsDeleted = 1, UpdatedAt = GETUTCDATE() WHERE Id = X
            // Au lieu de : DELETE FROM [table_T] WHERE Id = X
        }
    }
}



*/