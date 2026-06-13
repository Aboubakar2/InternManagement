using InterManagement.Application.Features.Feedbacks.DTOs;

namespace InterManagement.Application.Features.Feedbacks.Commands.UpdateFeedback
{
    public class UpdateFeedbackCommand
    {
        public int Id { get; set; }
        public UpdateFeedbackDto Data { get; set; }

        public UpdateFeedbackCommand(int id, UpdateFeedbackDto data)
        {
            Id   = id;
            Data = data;
        }
    }
}