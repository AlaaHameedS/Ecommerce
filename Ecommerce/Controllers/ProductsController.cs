using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceDbContext _context;

        public ProductsController(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Response = await _context.Products.Include(x=>x.Category).OrderBy(x=>x.Price) .ToListAsync();
            return View(Response);
        }
    }
}
