using Ecommerce.Models;
using System.Linq.Expressions;

namespace Ecommerce.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsycn();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] include);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include);
        Task<T> GetByIdAsycn(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChanges();
    }
}
