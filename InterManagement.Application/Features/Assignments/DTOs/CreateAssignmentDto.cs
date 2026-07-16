namespace InterManagement.Application.Features.Assignments.DTOs
{
    public class CreateAssignmentDto
    {
        public int TraineeId { get; set; }
        public int MentorId { get; set; }
        public int PhaseId { get; set; }
    }
}