using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Feedbacks.Commands.DeleteFeedback
{
    public class DeleteFeedbackHandler
    {
        private readonly IFeedbackRepository _repository;

        public DeleteFeedbackHandler(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteFeedbackCommand command)
        {
            var feedback = await _repository
                .GetByIdAsync(command.Id);
            if (feedback == null)
                throw new FeedbackNotFoundException(command.Id);

            await _repository.DeleteAsync(command.Id);
        }
    }
}