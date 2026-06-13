using InterManagement.Domain.Entities;

namespace InterManagement.Domain.Repositories
{
    public interface IPhaseRepository : IBaseRepository<Phase>
    {
        // Stagiaire → ses phases
        Task<IEnumerable<Phase>> GetByTraineeAsync(int traineeId);

        // Stagiaire → sa phase en cours
        Task<Phase?> GetCurrentPhaseAsync(int traineeId);

        // Admin → une phase avec ses suivis
        Task<Phase?> GetWithFollowUpsAsync(int phaseId);
    }
}