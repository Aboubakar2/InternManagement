using InterManagement.Application.Features.Mentors.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Mentors.Queries.GetMentorById
{
    public class GetMentorByIdHandler
    {
        private readonly IMentorRepository _repository;

        public GetMentorByIdHandler(IMentorRepository repository)
        {
            _repository = repository;
        }

        public async Task<MentorDetailDto> Handle(GetMentorByIdQuery query)
        {
            var mentor = await _repository.GetByIdAsync(query.Id);
            if (mentor == null)
                throw new MentorNotFoundException(query.Id);

            return new MentorDetailDto
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