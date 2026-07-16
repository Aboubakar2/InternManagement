using InterManagement.Application.Features.Feedbacks.DTOs;

namespace InterManagement.Application.Features.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommand
    {
        public CreateFeedbackDto Data { get; set; }

        public CreateFeedbackCommand(CreateFeedbackDto data)
        {
            Data = data;
        }
    }
}