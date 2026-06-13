using InterManagement.Domain.Entities;

namespace InterManagement.Domain.Repositories
{
    public interface IFeedbackRepository : IBaseRepository<Feedback>
    {
        // Stagiaire → ses feedbacks
        Task<IEnumerable<Feedback>> GetByTraineeAsync(int traineeId);

        // Admin → feedbacks récents
        Task<IEnumerable<Feedback>> GetRecentFeedbacksAsync(
            int traineeId, int count);
    }
}