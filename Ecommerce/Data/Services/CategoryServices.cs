
using Ecommerce.Data.Base;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Services
{
    public class CategoryServices : EntityBaseRepository<Category>, ICategoryServices
    {
       
        public CategoryServices(EcommerceDbContext context):base(context) 
        {
            
        }

       

    }
}
