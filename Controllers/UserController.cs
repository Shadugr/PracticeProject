using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Data.Entities;
using PracticeProject.Migrations;
using System.Collections;

namespace PracticeProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjectDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _appEnvironment;

        public UserController(ProjectDbContext context, SignInManager<User> signInManager, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _signInManager = signInManager;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Logout()
        {
            var findUser = _context.Users.Include(user => user.Adverts)
                .Where(user => user.Email == User.Identity.Name).First();
            findUser.IsActive = false;
            await _context.SaveChangesAsync();
            await _signInManager.SignOutAsync();
            return Redirect("~/Home/Index");
        }

        public IActionResult Profile()
        {
            var findUser = _context.Users.Where(user => user.Email == User.Identity.Name).First();
            if (findUser == null)
                return NotFound();
            return Redirect($"~/User/UserProfile/{findUser.Id}");
        }
        public async Task<IActionResult> Delete()
        {
            var delUser = _context.Users.Where(user => user.Email == User.Identity.Name).First();
            await _signInManager.SignOutAsync();
            _context.Remove(delUser);
            await _context.SaveChangesAsync();
            return Redirect("~/Home/Index");
        }

        public IActionResult UserProfile(string id)
        {
            var findUser = _context.Users
                .Include(user => user.Adverts).ThenInclude(advert => advert.Flat)
                .Include(user => user.Adverts).ThenInclude(advert => advert.Land)
                .Include(user => user.Adverts).ThenInclude(advert => advert.Photos)
                .Where(user => user.Id == id).First();
            if (findUser == null || findUser.Adverts == null || id == null)
                return NotFound();
            return View(findUser);
        }

        public IActionResult ProfileSettings(string id)
        {
            var findUser = _context.Users.Where(user => user.Id == id).First();
            if (findUser == null || id == null || User.Identity.Name != findUser.Email)
                return NotFound();
            return View(findUser);
        }
        [HttpPost]
        public IActionResult ProfileSettings(User formUser)
        {
            var findUser = _context.Users.Where(user => user.Email == formUser.Email).First();
            if (findUser == null || User.Identity.Name != findUser.Email)
                return NotFound();

            findUser.Name = formUser.Name;
            findUser.Surname = formUser.Surname;
            findUser.PhoneNumber = formUser.PhoneNumber;
            _context.SaveChanges();
            return View(findUser);
        }

        public IActionResult FlatCreate()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("~/Home/Index");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FlatCreate(string inputTitle, string inputLocation,
            List<IFormFile> inputMultipleImages, int inputFloor, int inputStorey, int inputSquare,
            int inputBuildAge, int inputPrice, string inputDescription)
        {
            var user = _context.Users.Where(user => user.Email == User.Identity.Name).First();
            Advert createAdvert = new()
            {
                Title = inputTitle,
                Location = inputLocation,
                Price = inputPrice,
                Description = inputDescription,
                CreatedAt = DateTime.Now,
                Flat = new()
                {
                    Floor = inputFloor,
                    Storey = inputStorey,
                    Square = inputSquare,
                    BuildingAge = inputBuildAge,
                },
                User = user
            };
            await _context.Adverts.AddAsync(createAdvert);
            await _context.SaveChangesAsync();
            var newAdvert = _context.Adverts.Where(advert => advert.UserId == user.Id
            && advert.CreatedAt == createAdvert.CreatedAt).First();
            newAdvert.Photos = await GetPhotosFromForm(inputMultipleImages, newAdvert);
            await _context.SaveChangesAsync();
            return Redirect($"~/Home/FlatView/{newAdvert.Id}");
        }

        public IActionResult LandCreate()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("~/Home/Index");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LandCreate(string inputTitle, string inputLocation,
            List<IFormFile> inputMultipleImages, string typeOfLand, int inputArea,
            string areaDimension, int inputPrice, string inputDescription)
        {
            var user = _context.Users.Where(user => user.Email == User.Identity.Name).First();
            Advert createAdvert = new()
            {
                Title = inputTitle,
                Location = inputLocation,
                Price = inputPrice,
                Description = inputDescription,
                CreatedAt = DateTime.Now,
                Land = new()
                {
                    TypeOfLand = typeOfLand,
                    Area = inputArea,
                    AreaDimension = areaDimension
                },
                User = user
            };
            await _context.Adverts.AddAsync(createAdvert);
            await _context.SaveChangesAsync();
            var newAdvert = _context.Adverts.Where(advert => advert.UserId == user.Id
            && advert.CreatedAt == createAdvert.CreatedAt).First();
            newAdvert.Photos = await GetPhotosFromForm(inputMultipleImages, newAdvert);
            await _context.SaveChangesAsync();
            return Redirect($"~/Home/FlatView/{newAdvert.Id}");
        }

        public IActionResult FlatUpdate(int id)
        {
            var newAdvert = _context.Adverts.Include(advert => advert.Flat)
                .Include(advert => advert.Photos).Where(advert => advert.Id == id).First();
            var user = _context.Users.Where(user => user.Id == newAdvert.UserId).First();
            if (!User.Identity.IsAuthenticated && user is null 
                && User.Identity.Name != user.Email)
                return Redirect("~/Home/Index");
            return View(newAdvert);
        }
        [HttpPost]
        public async Task<IActionResult> FlatUpdate(int inputId, string inputTitle, string inputLocation,
            List<IFormFile> inputMultipleImages, int inputFloor, int inputStorey, int inputSquare,
            int inputBuildAge, int inputPrice, string inputDescription)
        {
            var newAdvert = _context.Adverts.Include(advert => advert.Flat)
                .Include(advert => advert.Photos).Where(advert => advert.Id == inputId).First();
            newAdvert.Title = inputTitle;
            newAdvert.Location = inputLocation;
            newAdvert.Flat.Floor = inputFloor;
            newAdvert.Flat.Storey = inputStorey;
            newAdvert.Flat.Square = inputSquare;
            newAdvert.Flat.BuildingAge = inputBuildAge;
            newAdvert.Price = inputPrice;
            newAdvert.Description = inputDescription;
            if (inputMultipleImages.Count > 0)
            {
                string rootPath = Path
                    .Combine(_appEnvironment.WebRootPath.ToString(), "img", newAdvert.Id.ToString());
                Directory.Delete(rootPath, true);
                newAdvert.Photos = await GetPhotosFromForm(inputMultipleImages, newAdvert);
            }
            await _context.SaveChangesAsync();
            return Redirect($"~/Home/FlatView/{newAdvert.Id}");
        }

        public IActionResult LandUpdate(int id)
        {
            var newAdvert = _context.Adverts.Include(advert => advert.Land)
                .Include(advert => advert.Photos).Where(advert => advert.Id == id).First();
            var user = _context.Users.Where(user => user.Id == newAdvert.UserId).First();
            if (!User.Identity.IsAuthenticated && user is null
                && User.Identity.Name != user.Email)
                return Redirect("~/Home/Index");
            return View(newAdvert);
        }
        [HttpPost]
        public async Task<IActionResult> LandUpdate(int inputId, string inputTitle, 
            string inputLocation, List<IFormFile> inputMultipleImages, string typeOfLand, 
            int inputArea, string areaDimension, int inputPrice, string inputDescription)
        {
            var newAdvert = _context.Adverts.Include(advert => advert.Land)
                .Include(advert => advert.Photos).Where(advert => advert.Id == inputId).First();
            newAdvert.Title = inputTitle;
            newAdvert.Location = inputLocation;
            newAdvert.Land.TypeOfLand = typeOfLand;
            newAdvert.Land.Area = inputArea;
            newAdvert.Land.AreaDimension = areaDimension;
            newAdvert.Price = inputPrice;
            newAdvert.Description = inputDescription;
            if (inputMultipleImages.Count > 0)
            {
                string rootPath = Path
                    .Combine(_appEnvironment.WebRootPath.ToString(), "img", newAdvert.Id.ToString());
                Directory.Delete(rootPath, true);
                newAdvert.Photos = await GetPhotosFromForm(inputMultipleImages, newAdvert);
            }
            await _context.SaveChangesAsync();
            return Redirect($"~/Home/FlatView/{newAdvert.Id}");
        }

        public async Task<IActionResult> ChangeAdvertActivation(int id)
        {
            var searchAdvert = _context.Adverts.Where(advert => advert.Id == id).First();
            var user = _context.Users.Where(user => user.Email == User.Identity.Name).First();
            searchAdvert.IsActive = !searchAdvert.IsActive;
            await _context.SaveChangesAsync();
            return Redirect($"~/User/UserProfile/{user.Id}");
        }
        public async Task<IActionResult> DeleteAdvert(int id)
        {
            var searchAdvert = _context.Adverts.Where(advert => advert.Id == id).First();
            var user = _context.Users.Where(user => user.Email == User.Identity.Name).First();
            string rootPath = Path
                    .Combine(_appEnvironment.WebRootPath.ToString(), "img", searchAdvert.Id.ToString());
            Directory.Delete(rootPath, true);
            _context.Adverts.Remove(searchAdvert);
            await _context.SaveChangesAsync();
            return Redirect($"~/User/UserProfile/{user.Id}");
        }

        public async Task<List<Photo>> GetPhotosFromForm(List<IFormFile> inputMultipleImages, Advert advert)
        {
            List<Photo> photos = new();
            string rootPath = Path
                .Combine(_appEnvironment.WebRootPath.ToString(), "img", advert.Id.ToString());
            Directory.CreateDirectory(rootPath);
            foreach (var image in inputMultipleImages)
            {
                string filePath = Path.Combine(rootPath, image.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                photos.Add(new()
                {
                    PathToFile = $"img/{advert.Id}/{image.FileName}"
                });
            }
            return photos;
        }
    }
}
