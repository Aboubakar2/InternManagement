
using InterManagement.Domain.Entities;

namespace InterManagement.Domain.Repositories
{
    public interface IMentorRepository : IBaseRepository<Mentor>
    {
        Task<IEnumerable<Mentor>> GetAssignmentTraineesAsync();

    }

}
