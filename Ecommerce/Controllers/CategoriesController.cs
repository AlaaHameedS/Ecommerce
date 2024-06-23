using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly EcommerceDbContext _context;

        public CategoriesController(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var Resoponse = await _context.Categories.ToListAsync();
            return View(Resoponse);
        }
    }
}
