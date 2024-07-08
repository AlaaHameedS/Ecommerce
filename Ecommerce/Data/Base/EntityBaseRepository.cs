
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecommerce.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<T> _entities;
        public EntityBaseRepository(EcommerceDbContext context)
        {
            this._context = context;
            _entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
           var entityId= await _entities.FirstOrDefaultAsync(x => x.Id==id);
            if (entityId != null) 
            { 
                _entities.Remove(entityId);
                await SaveChanges();
            }

        }

        public async Task<IEnumerable<T>> GetAllAsycn()
        {
            return await _entities.ToListAsync();
        }

        public Task<T> GetByIdAsycn(int id)
        {
            return _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)   
        {
            EntityEntry entityEntry= _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await SaveChanges();
        }
    }
}
