namespace InterManagement.Application.Features.Assignments.Commands.DeactivateAssignment
{
    public class DeactivateAssignmentCommand
    {
        public int Id { get; set; }

        public DeactivateAssignmentCommand(int id)
        {
            Id = id;
        }
    }
}