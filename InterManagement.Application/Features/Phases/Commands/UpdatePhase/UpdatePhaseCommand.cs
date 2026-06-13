using InterManagement.Application.Features.Phases.DTOs;

namespace InterManagement.Application.Features.Phases.Commands.UpdatePhase
{
    public class UpdatePhaseCommand
    {
        public int Id { get; set; }
        public UpdatePhaseDto Data { get; set; }

        public UpdatePhaseCommand(int id, UpdatePhaseDto data)
        {
            Id   = id;
            Data = data;
        }
    }
}