using AnyarMVC.Areas.Manage.ViewModels;
using AnyarMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace AnyarMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminVM)
        {
            if (adminVM == null) NotFound();
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(adminVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password incorrect!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, adminVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect!");
                return View();
            }
                return RedirectToAction("Index","Dashboard");
        }
    }
}
