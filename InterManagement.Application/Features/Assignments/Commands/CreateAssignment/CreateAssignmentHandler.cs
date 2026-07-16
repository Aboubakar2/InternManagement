using InterManagement.Application.Features.Assignments.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentHandler
    {
        private readonly IAssignmentRepository _repository;
        private readonly ITraineeRepository    _traineeRepository;
        private readonly IMentorRepository     _mentorRepository;
        private readonly IPhaseRepository      _phaseRepository;

        public CreateAssignmentHandler(
            IAssignmentRepository assignmentRepository,
            ITraineeRepository    traineeRepository,
            IMentorRepository     mentorRepository,
            IPhaseRepository      phaseRepository)
        {
            _repository        = assignmentRepository;
            _traineeRepository = traineeRepository;
            _mentorRepository  = mentorRepository;
            _phaseRepository   = phaseRepository;
        }

        public async Task<AssignmentDto> Handle(
            CreateAssignmentCommand command)
        {
            // 1. Vérifier Trainee existe
            var trainee = await _traineeRepository
                .GetByIdAsync(command.Data.TraineeId);
            if (trainee == null)
                throw new TraineeNotFoundException(
                    command.Data.TraineeId);

            // 2. Vérifier Mentor existe
            var mentor = await _mentorRepository
                .GetByIdAsync(command.Data.MentorId);
            if (mentor == null)
                throw new MentorNotFoundException(
                    command.Data.MentorId);

            // 3. Vérifier Phase existe
            var phase = await _phaseRepository
                .GetByIdAsync(command.Data.PhaseId);
            if (phase == null)
                throw new PhaseNotFoundException(
                    command.Data.PhaseId);

            // 4. Vérifier assignment pas déjà existant
            var exists = await _repository.AssignmentExistsAsync(
                command.Data.TraineeId,
                command.Data.MentorId,
                command.Data.PhaseId);
            if (exists)
                throw new AssignmentAlreadyExistsException(
                    command.Data.TraineeId,
                    command.Data.MentorId,
                    command.Data.PhaseId);

            // 5. Créer l'Assignment
            var assignment = new Assignment(
                command.Data.TraineeId,
                command.Data.MentorId,
                command.Data.PhaseId
            );

            // 6. Sauvegarder
            await _repository.AddAsync(assignment);

            // 7. Retourner DTO
            return new AssignmentDto
            {
                Id             = assignment.Id,
                AssignmentDate = assignment.AssignmentDate,
                IsActive       = assignment.IsActive,
                TraineeId      = assignment.TraineeId,
                TraineeName    = $"{trainee.FirstName} {trainee.LastName}",
                MentorId       = assignment.MentorId,
                MentorName     = $"{mentor.FirstName} {mentor.LastName}",
                PhaseId        = assignment.PhaseId,
                PhaseTitle     = phase.Title
            };
        }
    }
}