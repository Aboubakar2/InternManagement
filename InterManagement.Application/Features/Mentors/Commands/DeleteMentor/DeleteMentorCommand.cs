namespace InterManagement.Application.Features.Mentors.Commands.DeleteMentor
{
    public class DeleteMentorCommand
    {
        public int Id { get; set; }

        public DeleteMentorCommand(int id)
        {
            Id = id;
        }
    }
}