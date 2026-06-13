using InterManagement.Domain.Entities;

namespace InterManagement.Application.Features.Phases.DTOs
{
    public class PhaseDetailDto
    {
        public int Id { get; set; }
        public int PhaseNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Objective { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public PhaseStatus Status { get; set; }
        public int TraineeId { get; set; }
        // public ICollection<WeeklyFollowUpDto> WeeklyFollowUps { get; set; } = [];
        // ← décommenter quand WeeklyFollowUp créé
    }
}
