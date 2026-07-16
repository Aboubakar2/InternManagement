namespace InterManagement.Application.Features.Mentors.Queries.GetMentors
{
    public class GetMentorsQuery
    {
        public string? Department { get; set; }
        // null → tous les mentors
        // "IT" → seulement département IT
    }
}