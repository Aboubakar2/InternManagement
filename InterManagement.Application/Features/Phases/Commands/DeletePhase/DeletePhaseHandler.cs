using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Phases.Commands.DeletePhase
{
    public class DeletePhaseHandler
    {
        private readonly IPhaseRepository _repository;

        public DeletePhaseHandler(IPhaseRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePhaseCommand command)
        {
            var phase = await _repository.GetByIdAsync(command.Id);
            if (phase == null)
                throw new PhaseNotFoundException(command.Id);

            await _repository.DeleteAsync(command.Id);
        }
    }
}