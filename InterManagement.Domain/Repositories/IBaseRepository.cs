
using InterManagement.Domain.Entities;

namespace InterManagement.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync();      
        Task<T?> GetByIdAsync(int id);
        Task<T>  AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
