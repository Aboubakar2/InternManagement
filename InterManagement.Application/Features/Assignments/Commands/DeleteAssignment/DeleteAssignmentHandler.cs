using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentHandler
    {
        private readonly IAssignmentRepository _repository;

        public DeleteAssignmentHandler(
            IAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAssignmentCommand command)
        {
            var assignment = await _repository.GetByIdAsync(command.Id);
            if (assignment == null)
                throw new AssignmentNotFoundException(command.Id);

            await _repository.DeleteAsync(command.Id);
        }
    }
}