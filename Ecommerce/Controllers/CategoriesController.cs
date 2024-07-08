using Ecommerce.Data;
using Ecommerce.Data.Services;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Ecommerce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _services;

        public CategoriesController(ICategoryServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var Resoponse = await _services.GetAllAsycn();
            return View(Resoponse);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        public async Task<IActionResult> Details(int id)
        {
            var category = await _services.GetByIdAsycn(id);
            if (category != null)
            {
                return View(category);
            }

            return NotFound();
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _services.GetByIdAsycn(id);
            if (category != null)
            {
                return View(category);
            }

            return NotFound() ;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
           //var  categoryId = await _services.GetByIdAsycn(category.Id);
            if (!ModelState.IsValid /*&& categoryId==null*/)
            {
                return NotFound();
            }
            await _services.UpdateAsync(category);
            return RedirectToAction(nameof(Index));
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
