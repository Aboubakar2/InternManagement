using InterManagement.Application.Features.Assignments.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Assignments.Queries.GetAssignmentById
{
    public class GetAssignmentByIdHandler
    {
        private readonly IAssignmentRepository _repository;

        public GetAssignmentByIdHandler(
            IAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<AssignmentDto> Handle(
            GetAssignmentByIdQuery query)
        {
            var assignment = await _repository
                .GetByIdAsync(query.Id);
            if (assignment == null)
                throw new AssignmentNotFoundException(query.Id);

            return new AssignmentDto
            {
                Id             = assignment.Id,
                AssignmentDate = assignment.AssignmentDate,
                IsActive       = assignment.IsActive,
                TraineeId      = assignment.TraineeId,
                TraineeName    = $"{assignment.Trainee.FirstName} {assignment.Trainee.LastName}",
                MentorId       = assignment.MentorId,
                MentorName     = $"{assignment.Mentor.FirstName} {assignment.Mentor.LastName}",
                PhaseId        = assignment.PhaseId,
                PhaseTitle     = assignment.Phase.Title
            };
        }
    }
}