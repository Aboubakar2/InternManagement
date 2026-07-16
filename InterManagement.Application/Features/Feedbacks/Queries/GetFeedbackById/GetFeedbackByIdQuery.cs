namespace InterManagement.Application.Features.Feedbacks.Queries.GetFeedbackById
{
    public class GetFeedbackByIdQuery
    {
        public int Id { get; set; }

        public GetFeedbackByIdQuery(int id)
        {
            Id = id;
        }
    }
}