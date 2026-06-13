using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.InternFiles.Commands.DeleteInternFile
{
    public class DeleteInternFileHandler
    {
        private readonly IInternFileRepository _repository;

        public DeleteInternFileHandler(
            IInternFileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteInternFileCommand command)
        {
            var file = await _repository
                .GetByIdAsync(command.Id);
            if (file == null)
                throw new InternFileNotFoundException(command.Id);

            await _repository.DeleteAsync(command.Id);
        }
    }
}