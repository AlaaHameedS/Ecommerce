using Ecommerce.Data;
using Ecommerce.Data.Services;
using Ecommerce.Data.Static;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
       
        private readonly IProductServices _services;
        private readonly ICategoryServices _categoriesService;
        

        public ProductsController(IProductServices services, ICategoryServices categoryServices)
        {
            _services = services;
            _categoriesService = categoryServices;

        }
        public async Task<IActionResult> Index(string SearchTerm)
        {

            var Response = await _services.GetAllAsync(x => x.Category);
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Response = Response.Where(x => x.Name.Contains(SearchTerm)).ToList();
            }

            return View(Response);
        }


        public async Task<IActionResult> Details(int id)
        {

            var Product = await _services.GetByIdAsync(id, x => x.Category);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);

            
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = await _categoriesService.GetAllAsycn();
            return View("Create");
        }

        [HttpPost, ActionName(nameof(Create))]
        public async Task<IActionResult> CreateProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                await _services.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");


        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Category = await _categoriesService.GetAllAsync();
            var productId = await _services.GetByIdAsync(id, x => x.Category);

            if (productId == null)
            {
                return NotFound();
            }

            return View(productId);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                //Update
                await _services.UpdateAsync(product);
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "There was an error processing your request.");
            }
            return View(product);



        }

        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }






    }

}

