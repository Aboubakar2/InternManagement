namespace InterManagement.Application.Features.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQuery
    {
        public int Id { get; set; }

        public GetAssignmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}