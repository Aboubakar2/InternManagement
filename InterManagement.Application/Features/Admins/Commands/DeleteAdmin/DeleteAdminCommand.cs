namespace InterManagement.Application.Features.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommand
    {
        public int Id { get; set; }

        public DeleteAdminCommand(int id)
        {
            Id = id;
        }
    }
}