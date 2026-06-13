using InterManagement.Application.Features.Admins.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Admins.Commands.UpdateAdmin
{
    public class UpdateAdminHandler
    {
        private readonly IAdminRepository _repository;

        public UpdateAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdminDto> Handle(UpdateAdminCommand command)
        {
            // 1. Chercher l'admin
            var admin = await _repository.GetByIdAsync(command.Id);
            if (admin == null)
                throw new AdminNotFoundException(command.Id);

            // 2. Vérifier actif
            if (!admin.IsActive)
                throw new AdminNotActiveException(command.Id);

            // 3. Modifier via méthode Update
            admin.Update(
                command.Data.FirstName,
                command.Data.LastName,
                command.Data.Email
            );

            // 4. Sauvegarder
            await _repository.UpdateAsync(admin);

            // 5. Retourner DTO
            return new AdminDto
            {
                Id        = admin.Id,
                FirstName = admin.FirstName,
                LastName  = admin.LastName,
                Email     = admin.Email,
                IsActive  = admin.IsActive
            };
        }
    }
}
