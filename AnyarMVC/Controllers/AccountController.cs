using AnyarMVC.Areas.Manage.ViewModels;
using AnyarMVC.Models;
using AnyarMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnyarMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
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
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (loginVM == null) NotFound();
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password incorrect!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect!");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            if (registerVM == null) NotFound();
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(registerVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("Username", "Username is incorrect!");
            }
            user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email is incorrect!");
            }
            user = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                Fullname = registerVM.FullName,
            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                ModelState.AddModelError("", err.Description);
                return View();
                }
            }
            var roleresult = await _userManager.AddToRoleAsync(user, "Member");
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View();
                }
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Login", "Account");
        }
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
               await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Login","Account");
        }
    }
}
