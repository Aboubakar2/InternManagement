
namespace InterManagement.Domain.Entities
{


    public class BaseModel
    {
        public int Id { get; set; }    // ID unique de l'entité
        public DateTime CreatedAt { get; set; }   // Date de création
        public DateTime? UpdatedAt { get; set; }  // Date de dernière mise à jour (nullable)
        public bool IsDeleted { get; set; } = false; // Indique si l'entité est supprimé

    }   




}