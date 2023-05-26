using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Models;
using System.Diagnostics;
using PracticeProject.Data.Entities;
using System.Security.Claims;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private const int _MAX_PAGE_COUNT = 5;

        public HomeController(ProjectDbContext context, SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            return View(_context.Adverts
                .Where(advert => advert.Id > page * _MAX_PAGE_COUNT - _MAX_PAGE_COUNT 
                && advert.Id <= page * _MAX_PAGE_COUNT)
                .ToList());
        }
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> FlatView(int id)
        {
            var advert = _context.Adverts.Include(advert => advert.Flat)
                .Include(advert => advert.User)
                .Where(advert => advert.Id == id).First();
            if (advert.Flat == null)
                advert = _context.Adverts.Include(advert => advert.Land)
                    .Include(advert => advert.User)
                    .Where(advert => advert.Id == id).First();
            if (advert == null || id == null 
                || advert.User == null || (advert.Flat == null && advert.Land == null))
                return NotFound();
            advert.ViewNumber++;
            await _context.SaveChangesAsync();
            return View(advert);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}