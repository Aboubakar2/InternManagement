namespace InterManagement.Application.Features.Mentors.Queries.GetMentorById
{
    public class GetMentorByIdQuery
    {
        public int Id { get; set; }

        public GetMentorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
