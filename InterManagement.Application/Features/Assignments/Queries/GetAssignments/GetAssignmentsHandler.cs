using InterManagement.Application.Features.Assignments.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Assignments.Queries.GetAssignments
{
    public class GetAssignmentsHandler
    {
        private readonly IAssignmentRepository _repository;

        public GetAssignmentsHandler(IAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AssignmentDto>> Handle(
            GetAssignmentsQuery query)
        {
            IEnumerable<Assignment> assignments;

            if (query.MentorId.HasValue)
                assignments = await _repository
                    .GetByMentorAsync(query.MentorId.Value);
            else if (query.TraineeId.HasValue)
                assignments = await _repository
                    .GetByTraineeAsync(query.TraineeId.Value);
            else
                assignments = await _repository.GetAllAsync();

            return assignments.Select(a => new AssignmentDto
            {
                Id             = a.Id,
                AssignmentDate = a.AssignmentDate,
                IsActive       = a.IsActive,
                TraineeId      = a.TraineeId,
                TraineeName    = $"{a.Trainee.FirstName} {a.Trainee.LastName}",
                MentorId       = a.MentorId,
                MentorName     = $"{a.Mentor.FirstName} {a.Mentor.LastName}",
                PhaseId        = a.PhaseId,
                PhaseTitle     = a.Phase.Title
            });
        }
    }
}