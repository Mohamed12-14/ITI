using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using ITI_Project.Context;

namespace ITI_Project.Controllers
{
    public class UserController : Controller
    {
        ProductContext db = new ProductContext();

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password != user.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Passwords do not match.");
                    return View(user);
                }

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = db.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }
    }
}