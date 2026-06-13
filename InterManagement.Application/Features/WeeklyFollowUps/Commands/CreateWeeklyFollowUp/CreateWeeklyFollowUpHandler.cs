using InterManagement.Application.Features.WeeklyFollowUps.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.WeeklyFollowUps.Commands.CreateWeeklyFollowUp
{
    public class CreateWeeklyFollowUpHandler
    {
        private readonly IWeeklyFollowUpRepository _repository;
        private readonly ITraineeRepository        _traineeRepository;
        private readonly IMentorRepository         _mentorRepository;
        private readonly IPhaseRepository          _phaseRepository;

        public CreateWeeklyFollowUpHandler(
            IWeeklyFollowUpRepository repository,
            ITraineeRepository        traineeRepository,
            IMentorRepository         mentorRepository,
            IPhaseRepository          phaseRepository)
        {
            _repository        = repository;
            _traineeRepository = traineeRepository;
            _mentorRepository  = mentorRepository;
            _phaseRepository   = phaseRepository;
        }

        public async Task<WeeklyFollowUpDto> Handle(
            CreateWeeklyFollowUpCommand command)
        {
            // 1. Vérifier Trainee existe
            var trainee = await _traineeRepository.GetByIdAsync(command.Data.TraineeId);
            if (trainee == null)
                throw new TraineeNotFoundException(command.Data.TraineeId);

            // 2. Vérifier Mentor existe
            var mentor = await _mentorRepository.GetByIdAsync(command.Data.MentorId);
            if (mentor == null)
                throw new MentorNotFoundException(command.Data.MentorId);

            // 3. Vérifier Phase existe
            var phase = await _phaseRepository.GetByIdAsync(command.Data.PhaseId);
            if (phase == null)
                throw new PhaseNotFoundException(
                    command.Data.PhaseId);

            // 4. Vérifier suivi pas déjà existant
            var exists = await _repository
                .GetByTraineePhaseWeekAsync(
                    command.Data.TraineeId,
                    command.Data.PhaseId,
                    command.Data.WeekNumber);
            if (exists != null)
                throw new WeeklyFollowUpAlreadyExistsException(
                    command.Data.TraineeId,
                    command.Data.PhaseId,
                    command.Data.WeekNumber);

            // 5. Créer le suivi
            var followUp = new WeeklyFollowUp(
                command.Data.WeekNumber,
                command.Data.FollowUpDate,
                command.Data.Comment,
                command.Data.PhaseId,
                command.Data.TraineeId,
                command.Data.MentorId
            );

            // 6. Sauvegarder
            await _repository.AddAsync(followUp);

            // 7. Retourner DTO
            return new WeeklyFollowUpDto
            {
                Id           = followUp.Id,
                WeekNumber   = followUp.WeekNumber,
                FollowUpDate = followUp.FollowUpDate,
                Status       = followUp.Status,
                Comment      = followUp.Comment,
                TraineeId    = followUp.TraineeId,
                TraineeName  = $"{trainee.FirstName} {trainee.LastName}",
                MentorId     = followUp.MentorId,
                MentorName   = $"{mentor.FirstName} {mentor.LastName}",
                PhaseId      = followUp.PhaseId,
                PhaseTitle   = phase.Title
            };
        }
    }
}
