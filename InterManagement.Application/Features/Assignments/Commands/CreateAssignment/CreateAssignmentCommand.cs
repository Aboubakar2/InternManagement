using InterManagement.Application.Features.Assignments.DTOs;

namespace InterManagement.Application.Features.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommand
    {
        public CreateAssignmentDto Data { get; set; }

        public CreateAssignmentCommand(CreateAssignmentDto data)
        {
            Data = data;
        }
    }
}