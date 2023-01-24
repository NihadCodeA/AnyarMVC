using AnyarMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyarMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnyarDB _context;

        public HomeController(AnyarDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Team> list = _context.Teams.Include(x=>x.SocialMediaAccounts).OrderBy(x=>x.Order).Take(4).ToList();
            return View(list);
        }

    }
}