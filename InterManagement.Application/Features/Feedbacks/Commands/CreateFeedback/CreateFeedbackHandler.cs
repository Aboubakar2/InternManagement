using InterManagement.Application.Features.Feedbacks.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackHandler
    {
        private readonly IFeedbackRepository _repository;
        private readonly ITraineeRepository  _traineeRepository;

        public CreateFeedbackHandler(
            IFeedbackRepository feedbackRepository,
            ITraineeRepository  traineeRepository)
        {
            _repository        = feedbackRepository;
            _traineeRepository = traineeRepository;
        }

        public async Task<FeedbackDto> Handle(
            CreateFeedbackCommand command)
        {
            // 1. Vérifier Trainee existe
            var trainee = await _traineeRepository
                .GetByIdAsync(command.Data.TraineeId);
            if (trainee == null)
                throw new TraineeNotFoundException(
                    command.Data.TraineeId);

            // 2. Créer le Feedback
            var feedback = new Feedback(
                command.Data.Message,
                command.Data.TraineeId
            );

            // 3. Sauvegarder
            await _repository.AddAsync(feedback);

            // 4. Retourner DTO
            return new FeedbackDto
            {
                Id          = feedback.Id,
                Message     = feedback.Message,
                SentAt      = feedback.SentAt,
                TraineeId   = feedback.TraineeId,
                TraineeName = $"{trainee.FirstName} {trainee.LastName}"
            };
        }
    }
}