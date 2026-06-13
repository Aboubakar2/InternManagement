namespace InterManagement.Application.Features.Feedbacks.Queries.GetFeedbacks
{
    public class GetFeedbacksQuery
    {
        public int? TraineeId { get; set; }
        public int? Count { get; set; }
        // null → tous les feedbacks
        // int  → feedbacks d'un stagiaire précis
    }
}