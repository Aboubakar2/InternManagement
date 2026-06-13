using InterManagement.Application.Features.Mentors.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Mentors.Queries.GetMentors
{
    public class GetMentorsHandler
    {
        private readonly IMentorRepository _repository;

        public GetMentorsHandler(IMentorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MentorDto>> Handle(GetMentorsQuery query)
        {
            IEnumerable<Mentor> mentors;

            // filtre par département si fourni
            if (!string.IsNullOrWhiteSpace(query.Department))
                mentors = await _repository
                    .GetByDepartmentAsync(query.Department);
            else
                mentors = await _repository.GetAllAsync();

            return mentors.Select(m => new MentorDto
            {
                Id         = m.Id,
                FirstName  = m.FirstName,
                LastName   = m.LastName,
                Email      = m.Email,
                Department = m.Department,
                Specialty  = m.Specialty,
                IsActive   = m.IsActive
            });
        }
    }
}
