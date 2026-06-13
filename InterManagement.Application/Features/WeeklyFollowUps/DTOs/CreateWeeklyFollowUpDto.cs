namespace InterManagement.Application.Features.WeeklyFollowUps.DTOs
{
    public class CreateWeeklyFollowUpDto
    {
        public int WeekNumber { get; set; }
        public DateOnly FollowUpDate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int PhaseId { get; set; }
        public int TraineeId { get; set; }
        public int MentorId { get; set; }
    }
}