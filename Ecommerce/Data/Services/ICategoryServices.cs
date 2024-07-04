using Ecommerce.Models;

namespace Ecommerce.Data.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllAsycn();
        Task<Category> GetByIdAsycn(int id);
        Task CreateAsync (Category entity);
        Task UpdateAsync (Category entity);
        Task DeleteAsync (int id);



    }
}
