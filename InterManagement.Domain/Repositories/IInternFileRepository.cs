using InterManagement.Domain.Entities;

namespace InterManagement.Domain.Repositories
{
    public interface IInternFileRepository : IBaseRepository<InternFile>
    {
        // Trainee → ses fichiers
        Task<IEnumerable<InternFile>> GetByTraineeAsync(int traineeId);

        // Chercher par type de fichier
        Task<IEnumerable<InternFile>> GetByTypeAsync(
            int traineeId, string fileType);

        // Vérifier si fichier existe déjà
        Task<bool> FileExistsAsync(int traineeId, string fileName);
    }
}