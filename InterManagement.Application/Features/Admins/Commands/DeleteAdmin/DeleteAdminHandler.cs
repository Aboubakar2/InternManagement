using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminHandler
    {
        private readonly IAdminRepository _repository;

        public DeleteAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAdminCommand command)
        {
            var admin = await _repository.GetByIdAsync(command.Id);
            if (admin == null)
                throw new AdminNotFoundException(command.Id);

            await _repository.DeleteAsync(command.Id);
        }
    }
}