namespace InterManagement.Application.Features.WeeklyFollowUps.Commands.CompleteFollowUp
{
    public class CompleteFollowUpCommand
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;

        public CompleteFollowUpCommand(int id, string comment)
        {
            Id      = id;
            Comment = comment;
        }
    }
}