using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.WeeklyFollowUps.Commands.DeleteWeeklyFollowUp
{
    public class DeleteWeeklyFollowUpHandler
    {
        private readonly IWeeklyFollowUpRepository _repository;

        public DeleteWeeklyFollowUpHandler(
            IWeeklyFollowUpRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteWeeklyFollowUpCommand command)
        {
            var followUp = await _repository.GetByIdAsync(command.Id);
            if (followUp == null)
                throw new WeeklyFollowUpNotFoundException(command.Id);

            await _repository.DeleteAsync(command.Id);
        }
    }
}