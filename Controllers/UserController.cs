using Microsoft.AspNetCore.Mvc;

namespace PracticeProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }

        public IActionResult ProfileSettings()
        {
            return View();
        }

        public IActionResult FlatCreate()
        {
            return View();
        }
        
        public IActionResult LandCreate()
        {
            return View();
        }

        public IActionResult FlatUpdate()
        {
            return View();
        }

        public IActionResult LandUpdate()
        {
            return View();
        }
    }
}
