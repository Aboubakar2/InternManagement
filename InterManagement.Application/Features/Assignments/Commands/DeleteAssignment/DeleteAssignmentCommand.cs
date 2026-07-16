namespace InterManagement.Application.Features.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommand
    {
        public int Id { get; set; }

        public DeleteAssignmentCommand(int id)
        {
            Id = id;
        }
    }
}