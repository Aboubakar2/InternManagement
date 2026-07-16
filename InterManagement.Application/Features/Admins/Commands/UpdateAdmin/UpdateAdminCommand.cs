using InterManagement.Application.Features.Admins.DTOs;

namespace InterManagement.Application.Features.Admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommand
    {
        public int Id { get; set; }
        public UpdateAdminDto Data { get; set; }

        public UpdateAdminCommand(int id, UpdateAdminDto data)
        {
            Id   = id;
            Data = data;
        }
    }
}
