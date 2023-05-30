using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Models;
using System.Diagnostics;
using PracticeProject.Data.Entities;
using System.Security.Claims;
using System.Linq;

namespace PracticeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectDbContext _context;
        private const int _MAX_PAGE_COUNT = 5;

        public HomeController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var adverts = _context.Adverts.Include(advert => advert.Photos)
                .Where(advert => advert.IsActive == true).ToList();
            ViewBag.AdvertCount = adverts.Count;
            return View(adverts.Skip((page - 1) * _MAX_PAGE_COUNT).Take(_MAX_PAGE_COUNT).ToList());
        }
        [HttpPost]
        public IActionResult Index(string? searchType, string? inputDescription, string? inputLocation,
            int? lowPrice, int? upPrice, int? lowSquare, int? upSquare, int? lowFloor,
            int? upFloor, int? lowArea, int? upArea, string? areaDimension,
            string? typeOfLand)
        {
            List<Advert>? searchAdvert = null;

            if (searchType == "Flat")
            {
                searchAdvert = _context.Adverts.Include(advert => advert.Photos).Include(advert => advert.Flat).ToList();
                if (!string.IsNullOrEmpty(inputDescription))
                    searchAdvert = searchAdvert.Where(advert => advert.Description.Contains(inputDescription)).ToList();
                if (!string.IsNullOrEmpty(inputLocation))
                    searchAdvert = searchAdvert.Where(advert => advert.Location.Contains(inputLocation)).ToList();
                if (lowPrice is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Price >= lowPrice).ToList();
                if (upPrice is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Price <= upPrice).ToList();
                if (lowSquare is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Flat.Square >= lowSquare).ToList();
                if (upSquare is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Flat.Square <= upSquare).ToList();
                if (lowFloor is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Flat.Floor >= lowFloor).ToList();
                if (upFloor is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Flat.Floor <= upFloor).ToList();
            }
            else if (searchType == "Land")
            {
                searchAdvert = _context.Adverts.Include(advert => advert.Photos).Include(advert => advert.Land).ToList();
                if (!string.IsNullOrEmpty(inputDescription))
                    searchAdvert = searchAdvert.Where(advert => advert.Description.Contains(inputDescription)).ToList();
                if (!string.IsNullOrEmpty(inputLocation))
                    searchAdvert = searchAdvert.Where(advert => advert.Location.Contains(inputLocation)).ToList();
                if (lowPrice is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Price >= lowPrice).ToList();
                if (upPrice is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Price <= upPrice).ToList();
                if (lowArea is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Land.Area >= lowArea).ToList();
                if (upArea is not null)
                    searchAdvert = searchAdvert.Where(advert => advert.Land.Area <= upArea).ToList();
                if (!string.IsNullOrEmpty(areaDimension))
                    searchAdvert = searchAdvert.Where(advert => advert.Location.Contains(areaDimension)).ToList();
                if (!string.IsNullOrEmpty(typeOfLand))
                    searchAdvert = searchAdvert.Where(advert => advert.Location.Contains(typeOfLand)).ToList();
            }

            if (searchAdvert is null)
                return View(_context.Adverts.Include(advert => advert.Photos).Where(advert => advert.IsActive == true)
                    .Take(_MAX_PAGE_COUNT).ToList());
            ViewBag.AdvertCount = searchAdvert.Count;
            return View(searchAdvert);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> FlatView(int id)
        {
            var advert = _context.Adverts.Include(advert => advert.Photos).Include(advert => advert.Flat)
                .Include(advert => advert.User)
                .Where(advert => advert.Id == id && advert.IsActive == true).First();
            if (advert.Flat is null)
                advert = _context.Adverts.Include(advert => advert.Land)
                    .Include(advert => advert.User)
                    .Where(advert => advert.Id == id && advert.IsActive == true).First();
            if (advert is null || id == null
                || advert.User is null || (advert.Flat is null && advert.Land is null))
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