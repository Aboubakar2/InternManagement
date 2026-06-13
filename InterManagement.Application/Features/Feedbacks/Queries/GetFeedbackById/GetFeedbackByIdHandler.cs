using InterManagement.Application.Features.Feedbacks.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Feedbacks.Queries.GetFeedbackById
{
    public class GetFeedbackByIdHandler
    {
        private readonly IFeedbackRepository _repository;

        public GetFeedbackByIdHandler(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<FeedbackDto> Handle(
            GetFeedbackByIdQuery query)
        {
            var feedback = await _repository
                .GetByIdAsync(query.Id);
            if (feedback == null)
                throw new FeedbackNotFoundException(query.Id);

            return new FeedbackDto
            {
                Id          = feedback.Id,
                Message     = feedback.Message,
                SentAt      = feedback.SentAt,
                TraineeId   = feedback.TraineeId,
                TraineeName = $"{feedback.Trainee.FirstName} {feedback.Trainee.LastName}"
            };
        }
    }
}
