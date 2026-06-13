using InterManagement.Application.Features.Mentors.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Mentors.Commands.UpdateMentor
{
    public class UpdateMentorHandler
    {
        private readonly IMentorRepository _repository;

        public UpdateMentorHandler(IMentorRepository repository)
        {
            _repository = repository;
        }

        public async Task<MentorDto> Handle(UpdateMentorCommand command)
        {
            // 1. Chercher le mentor
            var mentor = await _repository.GetByIdAsync(command.Id);
            if (mentor == null)
                throw new MentorNotFoundException(command.Id);

            // 2. Vérifier actif
            if (!mentor.IsActive)
                throw new MentorNotActiveException(command.Id);

            // 3. Modifier via méthode Update du Domain
            mentor.Update(
                command.Data.FirstName,
                command.Data.LastName,
                command.Data.Email,
                command.Data.Department,
                command.Data.Specialty
            );

            // 4. Sauvegarder
            await _repository.UpdateAsync(mentor);

            // 5. Retourner DTO
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
