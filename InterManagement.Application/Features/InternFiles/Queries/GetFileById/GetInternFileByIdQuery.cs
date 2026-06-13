namespace InterManagement.Application.Features.InternFiles.Queries.GetInternFileById
{
    public class GetInternFileByIdQuery
    {
        public int Id { get; set; }

        public GetInternFileByIdQuery(int id)
        {
            Id = id;
        }
    }
}