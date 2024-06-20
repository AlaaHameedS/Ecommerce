using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class EcommerceDbContext: DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options):base (options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
