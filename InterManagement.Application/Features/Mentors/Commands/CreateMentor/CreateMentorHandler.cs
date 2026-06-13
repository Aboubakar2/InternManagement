using InterManagement.Application.Features.Mentors.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Mentors.Commands.CreateMentor
{
    public class CreateMentorHandler
    {
        private readonly IMentorRepository _repository;

        public CreateMentorHandler(IMentorRepository repository)
        {
            _repository = repository;
        }

        public async Task<MentorDto> Handle(CreateMentorCommand command)
        {
            // 1. Vérifier email existe déjà
            var emailExists = await _repository
                .EmailExistsAsync(command.Data.Email);
            if (emailExists)
                throw new MentorAlreadyExistsException(command.Data.Email);

            // 2. Créer l'entité
            var mentor = new Mentor(
                command.Data.FirstName,
                command.Data.LastName,
                command.Data.Email,
                command.Data.Department,
                command.Data.Specialty
            );

            // 3. Sauvegarder
            await _repository.AddAsync(mentor);

            // 4. Retourner DTO
            return new MentorDto
            {
                Id         = mentor.Id,
                FirstName  = mentor.FirstName,
                LastName   = mentor.LastName,
                Email      = mentor.Email,
                Department = mentor.Department,
                Specialty  = mentor.Specialty,
                IsActive   = mentor.IsActive
            };
        }
    }
}
