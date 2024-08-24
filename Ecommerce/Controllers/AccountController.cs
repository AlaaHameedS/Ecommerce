using Ecommerce.Data;
using Ecommerce.Data.Static;
using Ecommerce.Data.ViewModels;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(EcommerceDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<IActionResult> Users()
        {
            var Resposne = await _context.Users.ToListAsync();
            return View(Resposne);
        }
        public IActionResult Login()
        {
            var Resulte = new LoginVM();
            return View(Resulte);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                //Check Password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    var Result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction("Index", "Products");
                    }
                }
                return View(model);
            }
            return View(model);
        }

        public IActionResult Register()
        {
            var Result = new RegisterVM();
            return View(Result);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                return View(model);
            }
            var newUser = new ApplicationUser() { Email = model.EmailAddress, FullName = model.FullName, UserName = model.EmailAddress.Split('@')[0] };
            var Result = await _userManager.CreateAsync(newUser, model.Password);
            if (Result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return View("CompleteRegister");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Products");
        }

    }
}
