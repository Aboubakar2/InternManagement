// Client/Models/MentorViewModel.cs
using InterManagement.Application.Features.WeeklyFollowUps.DTOs;
using InterManagement.Application.Features.Feedbacks.DTOs;
using InterManagement.Application.Features.Trainees.DTOs;

namespace InterManagement.Client.Models
{
    public class MentorViewModel
    {
        public int MentorId { get; set; }
        public string MentorName { get; set; } = string.Empty;

        public List<MentorAssignedTraineeItem> StagiairesAssignes { get; set; } = [];

        public List<TraineeDto> Stagiaires { get; set; } = [];

        public List<FeedbackDto> HistoriqueFeedbacks { get; set; } = [];
    }
}
