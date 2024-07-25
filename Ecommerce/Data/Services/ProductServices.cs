using Ecommerce.Data.Base;
using Ecommerce.Models;

namespace Ecommerce.Data.Services
{
    public class ProductServices:EntityBaseRepository<Product>, IProductServices
    {
        public ProductServices(EcommerceDbContext context) : base(context)
        {
            
        }
    }
}
