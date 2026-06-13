using InterManagement.Domain.Entities;

namespace InterManagement.Domain.Repositories
{
    public interface IAssignmentRepository : IBaseRepository<Assignment>
    {
        // Vérifier si assignment actif existe
        Task<Assignment?> GetActiveAssignmentAsync(
            int traineeId, int phaseId);

        // Mentor → ses stagiaires assignés
        Task<IEnumerable<Assignment>> GetByMentorAsync(int mentorId);   // Pour quoi on dit à chaque fois  IEnumerable<Assignment> ça doit returné liste assignment .  et pour quoi on int mentorId à quoi ça sert

        // Admin → assignments d'un stagiaire
        Task<IEnumerable<Assignment>> GetByTraineeAsync(int traineeId);

        // Vérifier si mentor déjà assigné à cette phase
        Task<bool> AssignmentExistsAsync(
            int traineeId, int mentorId, int phaseId);
    }
}