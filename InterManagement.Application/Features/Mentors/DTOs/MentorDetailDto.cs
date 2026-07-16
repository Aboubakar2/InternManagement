namespace InterManagement.Application.Features.Mentors.DTOs
{
    public class MentorDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int TraineeCount { get; set; }
        // public ICollection<AssignmentDto> Assignments { get; set; } = [];
        // ← décommenter quand Assignment créé
    }
}
