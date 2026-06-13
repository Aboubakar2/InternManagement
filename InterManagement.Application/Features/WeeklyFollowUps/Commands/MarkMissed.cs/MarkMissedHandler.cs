using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.WeeklyFollowUps.Commands.MarkMissed
{
    public class MarkMissedHandler
    {
        private readonly IWeeklyFollowUpRepository _repository;

        public MarkMissedHandler(IWeeklyFollowUpRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(MarkMissedCommand command)
        {
            var followUp = await _repository
                .GetByIdAsync(command.Id);
            if (followUp == null)
                throw new WeeklyFollowUpNotFoundException(command.Id);

            // utilise méthode métier du Domain
            followUp.MarkMissed();
            await _repository.UpdateAsync(followUp);
        }
    }
}