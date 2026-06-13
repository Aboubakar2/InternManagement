namespace InterManagement.Application.Features.Phases.Queries.GetPhaseById
{
    public class GetPhaseByIdQuery
    {
        public int Id { get; set; }

        public GetPhaseByIdQuery(int id)
        {
            Id = id;
        }
    }
}