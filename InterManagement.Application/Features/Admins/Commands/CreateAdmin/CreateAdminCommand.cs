using InterManagement.Application.Features.Admins.DTOs;

namespace InterManagement.Application.Features.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommand
    {
        public CreateAdminDto Data { get; set; }

        public CreateAdminCommand(CreateAdminDto data)
        {
            Data = data;
        }
    }
}
