namespace InterManagement.Application.Features.Feedbacks.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }

        // infos relation
        public int TraineeId { get; set; }
        public string TraineeName { get; set; } = string.Empty;
    }
}