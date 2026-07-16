using InterManagement.Application.Features.WeeklyFollowUps.DTOs;

namespace InterManagement.Application.Features.WeeklyFollowUps.Commands.CreateWeeklyFollowUp
{
    public class CreateWeeklyFollowUpCommand
    {
        public CreateWeeklyFollowUpDto Data { get; set; }

        public CreateWeeklyFollowUpCommand(CreateWeeklyFollowUpDto data)
        {
            Data = data;
        }
    }
}