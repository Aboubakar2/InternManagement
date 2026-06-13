namespace InterManagement.Application.Features.Assignments.DTOs
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public DateTime AssignmentDate { get; set; }
        public bool IsActive { get; set; }

        // infos des relations
        public int TraineeId { get; set; }
        public string TraineeName { get; set; } = string.Empty;

        public int MentorId { get; set; }
        public string MentorName { get; set; } = string.Empty;

        public int PhaseId { get; set; }
        public string PhaseTitle { get; set; } = string.Empty;
    }
}