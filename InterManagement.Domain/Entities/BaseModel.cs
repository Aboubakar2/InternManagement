namespace InterManagement.Domain.Entities
{
    
    // Champs communs à toutes les entités persistées : identifiant,
   
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}