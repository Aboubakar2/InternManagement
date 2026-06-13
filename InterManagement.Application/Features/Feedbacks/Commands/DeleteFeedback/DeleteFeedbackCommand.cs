namespace InterManagement.Application.Features.Feedbacks.Commands.DeleteFeedback
{
    public class DeleteFeedbackCommand
    {
        public int Id { get; set; }

        public DeleteFeedbackCommand(int id)
        {
            Id = id;
        }
    }
}