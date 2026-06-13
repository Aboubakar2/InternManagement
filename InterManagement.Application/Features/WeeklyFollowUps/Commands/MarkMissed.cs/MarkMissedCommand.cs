namespace InterManagement.Application.Features.WeeklyFollowUps.Commands.MarkMissed
{
    public class MarkMissedCommand
    {
        public int Id { get; set; }

        public MarkMissedCommand(int id)
        {
            Id = id;
        }
    }
}