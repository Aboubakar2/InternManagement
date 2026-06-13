namespace InterManagement.Application.Features.Feedbacks.DTOs
{
    public class CreateFeedbackDto
    {
        public string Message { get; set; } = string.Empty;
        public int TraineeId { get; set; }
    }
}