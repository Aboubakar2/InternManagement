using InterManagement.Application.Features.Admins.DTOs;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.Admins.Queries.GetAdmins
{
    public class GetAdminsHandler
    {
        private readonly IAdminRepository _repository;

        public GetAdminsHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AdminDto>> Handle(GetAdminsQuery query)
        {
            var admins = await _repository.GetAllAsync();

            return admins.Select(a => new AdminDto
            {
                Id        = a.Id,
                FirstName = a.FirstName,
                LastName  = a.LastName,
                Email     = a.Email,
                IsActive  = a.IsActive
            });
        }
    }
}