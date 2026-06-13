namespace InterManagement.Application.Features.InternFiles.Commands.DeleteInternFile
{
    public class DeleteInternFileCommand
    {
        public int Id { get; set; }

        public DeleteInternFileCommand(int id)
        {
            Id = id;
        }
    }
}