using AnyarMVC.Helpers;
using AnyarMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnyarMVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly AnyarDB _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AnyarDB context,IWebHostEnvironment env)
        {
            _context = context;
           _env = env;
        }
        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.Include(x=>x.SocialMediaAccounts).ToList();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if(team == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (team.ImageFile != null)
            {
                team.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/teams",team.ImageFile);
            }
            else
            {
                ModelState.AddModelError("ImageFile", "The Image field is required!");
            }
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }  
        
        public IActionResult Update(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x=>x.Id == id);
            if(team == null) return NotFound();
            if (!ModelState.IsValid) return View();
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            Team existTeam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);
            if (existTeam == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (team.ImageFile != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/teams",existTeam.Image);
                team.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/teams",team.ImageFile);
            }
            existTeam.Fullname= team.Fullname;
            existTeam.Postion=team.Postion;
            existTeam.About=team.About;
            existTeam.Order=team.Order;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (team.Image != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/teams", team.Image);
            }
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
