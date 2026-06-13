namespace InterManagement.Application.Features.Phases.Commands.DeletePhase
{
    public class DeletePhaseCommand
    {
        public int Id { get; set; }

        public DeletePhaseCommand(int id)
        {
            Id = id;
        }
    }
}