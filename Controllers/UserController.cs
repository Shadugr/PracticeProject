using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Data;
using PracticeProject.Data.Entities;

namespace PracticeProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjectDbContext _context;
        private readonly SignInManager<User> _signInManager;

        public UserController(ProjectDbContext context, SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
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
            var findUser = _context.Users.Include(user => user.Adverts)
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
    }
}
