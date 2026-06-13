using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Assignments.Commands.DeactivateAssignment
{
    public class DeactivateAssignmentHandler
    {
        private readonly IAssignmentRepository _repository;

        public DeactivateAssignmentHandler(
            IAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeactivateAssignmentCommand command)
        {
            var assignment = await _repository
                .GetByIdAsync(command.Id);
            if (assignment == null)
                throw new AssignmentNotFoundException(command.Id);

            // utilise la méthode métier du Domain
            assignment.Deactivate();
            await _repository.UpdateAsync(assignment);
        }
    }
}