using InterManagement.Domain.Exceptions;

namespace InterManagement.Domain.Entities
{
    public class Assignment : BaseModel
    {
        public DateTime AssignmentDate { get; private set; }
        public bool IsActive { get; private set; }

        // ── FKs ───────────────────────────────
        public int TraineeId { get; private set; }
        public Trainee Trainee { get; private set; } = null!;

        public int MentorId { get; private set; }
        public Mentor Mentor { get; private set; } = null!;

        public int PhaseId { get; private set; }
        public Phase Phase { get; private set; } = null!;

        private Assignment() { }

        public Assignment(
            int traineeId,
            int mentorId,
            int phaseId)
        {
            // ── Validations ───────────────────
            if (traineeId <= 0)
                throw new DomainException("Stagiaire est obligatoire");

            if (mentorId <= 0)
                throw new DomainException("Mentor est obligatoire");

            if (phaseId <= 0)
                throw new DomainException("Phase est obligatoire");

            // ── Assignation ───────────────────
            TraineeId      = traineeId;
            MentorId       = mentorId;
            PhaseId        = phaseId;
            AssignmentDate = DateTime.UtcNow;
            IsActive       = true;
        }

        // ── Méthodes métier ───────────────────
        public void Deactivate()
        {
            IsActive  = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive  = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}