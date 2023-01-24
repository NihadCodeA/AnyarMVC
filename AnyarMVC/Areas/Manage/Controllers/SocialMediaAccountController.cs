using AnyarMVC.Helpers;
using AnyarMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyarMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SocialMediaAccountController : Controller
    {
        private readonly AnyarDB _context;
        private readonly IWebHostEnvironment _env;

        public SocialMediaAccountController(AnyarDB context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<TeamSocialMediaAccount> teamsSM = _context.SocialMediaAccounts.Include(x=>x.Team).ToList();
            return View(teamsSM);
        }

        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams.Include(x=>x.SocialMediaAccounts).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamSocialMediaAccount teamSM)
        {
            ViewBag.Teams = _context.Teams.Include(x => x.SocialMediaAccounts).ToList();
            if (teamSM == null) return NotFound();
            if (!ModelState.IsValid) return View();
            
            _context.SocialMediaAccounts.Add(teamSM);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Teams = _context.Teams.Include(x => x.SocialMediaAccounts).ToList();
            TeamSocialMediaAccount team = _context.SocialMediaAccounts.FirstOrDefault(x=>x.Id== id);
            if (team == null) return NotFound();
            if (!ModelState.IsValid) return View();
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(TeamSocialMediaAccount teamSM)
        {
            ViewBag.Teams = _context.Teams.Include(x => x.SocialMediaAccounts).ToList();
            TeamSocialMediaAccount existTeamSM = _context.SocialMediaAccounts.Find(teamSM.Id);
            if (existTeamSM == null) return NotFound();
            if (!ModelState.IsValid) return View();

            existTeamSM.SocialMediaLink = teamSM.SocialMediaLink;
            existTeamSM.SocialMediaIcon = teamSM.SocialMediaIcon;
            existTeamSM.TeamId = teamSM.TeamId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            TeamSocialMediaAccount teamSM = _context.SocialMediaAccounts.FirstOrDefault(x => x.Id == id);
            if (teamSM == null) return NotFound();
            if (!ModelState.IsValid) return View();
            
            _context.SocialMediaAccounts.Remove(teamSM);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
