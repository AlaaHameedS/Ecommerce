
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly EcommerceDbContext _context;
        public CategoryServices(EcommerceDbContext context)
        {
            _context = context;
        }

       

        public async Task CreateAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var CategoryId= await _context.Categories.FirstOrDefaultAsync(x=> x.Id==id);
            if (CategoryId != null)
            { 
                 _context.Categories.Remove(CategoryId);
                await _context.SaveChangesAsync();
                
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsycn()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsycn(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
           var CategoryId = await _context.Categories.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (CategoryId != null) 
            {
                CategoryId.Id=entity.Id;
                CategoryId.Name=entity.Name;
                CategoryId.Description=entity.Description;
               
                await _context.SaveChangesAsync();

            }


        }
    }
}
