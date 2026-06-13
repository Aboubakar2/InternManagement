namespace InterManagement.Application.Features.WeeklyFollowUps.Commands.DeleteWeeklyFollowUp
{
    public class DeleteWeeklyFollowUpCommand
    {
        public int Id { get; set; }

        public DeleteWeeklyFollowUpCommand(int id)
        {
            Id = id;
        }
    }
}