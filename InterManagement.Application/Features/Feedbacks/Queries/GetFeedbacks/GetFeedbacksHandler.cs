using InterManagement.Application.Features.Feedbacks.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Feedbacks.Queries.GetFeedbacks
{
    public class GetFeedbacksHandler
    {
        private readonly IFeedbackRepository _repository;

        public GetFeedbacksHandler(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FeedbackDto>> Handle(
            GetFeedbacksQuery query)
        {
            IEnumerable<Feedback> feedbacks;

            if (query.TraineeId.HasValue && query.Count.HasValue)
                feedbacks = await _repository
                    .GetRecentFeedbacksAsync(
                        query.TraineeId.Value,
                        query.Count.Value);
            else if (query.TraineeId.HasValue)
                feedbacks = await _repository
                    .GetByTraineeAsync(query.TraineeId.Value);
            else
                feedbacks = await _repository.GetAllAsync();

            return feedbacks.Select(f => new FeedbackDto
            {
                Id          = f.Id,
                Message     = f.Message,
                SentAt      = f.SentAt,
                TraineeId   = f.TraineeId,
                TraineeName = $"{f.Trainee.FirstName} {f.Trainee.LastName}"
            });
        }
    }
}