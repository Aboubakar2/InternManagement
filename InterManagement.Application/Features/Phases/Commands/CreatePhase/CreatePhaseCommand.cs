using InterManagement.Application.Features.Phases.DTOs;

namespace InterManagement.Application.Features.Phases.Commands.CreatePhase
{
    public class CreatePhaseCommand
    {
        public CreatePhaseDto Data { get; set; }

        public CreatePhaseCommand(CreatePhaseDto data)
        {
            Data = data;
        }
    }
}
