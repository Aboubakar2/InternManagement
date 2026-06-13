using InterManagement.Domain.Entities;

namespace InterManagement.Domain.Repositories
{
    public interface IWeeklyFollowUpRepository
        : IBaseRepository<WeeklyFollowUp>
    {
        // Phase → ses suivis
        Task<IEnumerable<WeeklyFollowUp>> GetByPhaseAsync(int phaseId);

        // Mentor → ses suivis
        Task<IEnumerable<WeeklyFollowUp>> GetByMentorAsync(int mentorId);

        // Vérifier si suivi existe déjà
        Task<WeeklyFollowUp?> GetByTraineePhaseWeekAsync( int traineeId, int phaseId, int weekNumber);

        // Import massif Excel
        Task AddRangeAsync(IEnumerable<WeeklyFollowUp> followUps);
    }
}