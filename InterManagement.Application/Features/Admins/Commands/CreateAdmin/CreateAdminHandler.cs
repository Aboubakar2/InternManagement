using InterManagement.Application.Features.Admins.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Admins.Commands.CreateAdmin
{
    public class CreateAdminHandler
    {
        private readonly IAdminRepository _repository;

        public CreateAdminHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdminDto> Handle(CreateAdminCommand command)
        {
            // 1. Vérifier email
            var emailExists = await _repository
                .EmailExistsAsync(command.Data.Email);
            if (emailExists)
                throw new AdminAlreadyExistsException(command.Data.Email);

            // 2. Créer l'entité
            var admin = new Admin(
                command.Data.FirstName,
                command.Data.LastName,
                command.Data.Email
            );

            // 3. Sauvegarder
            await _repository.AddAsync(admin);

            // 4. Retourner DTO
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