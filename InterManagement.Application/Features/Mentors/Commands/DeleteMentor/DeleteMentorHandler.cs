using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Mentors.Commands.DeleteMentor
{
    public class DeleteMentorHandler
    {
        private readonly IMentorRepository _repository;

        public DeleteMentorHandler(IMentorRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteMentorCommand command)
        {
            var mentor = await _repository.GetByIdAsync(command.Id);
            if (mentor == null)
                throw new MentorNotFoundException(command.Id);

            await _repository.DeleteAsync(command.Id);
        }
    }
}
