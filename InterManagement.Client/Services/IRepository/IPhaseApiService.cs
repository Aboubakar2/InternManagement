// Services/IRepository/IPhaseApiService.cs
using InterManagement.Application.Features.Phases.Commands.CreatePhaseForMultipleTrainees;
using InterManagement.Application.Features.Phases.DTOs;

namespace InterManagement.Client.Services;

public interface IPhaseApiService
    : IBaseApiService<PhaseDto, CreatePhaseDto, UpdatePhaseDto>
{
    Task<List<PhaseDto>> GetByTraineeAsync(int traineeId);
    Task<PhaseDetailDto?> GetDetailsAsync(int id);

    Task<List<int>?> CreateForMultipleTraineesAsync(CreatePhaseForMultipleTraineesDto dto);
}
