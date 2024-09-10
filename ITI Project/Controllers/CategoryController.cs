using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using ITI_Project.Context;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        ProductContext db = new ProductContext();

        [HttpGet]
        public IActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var oldCategory = db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
                if (oldCategory == null)
                {
                    return RedirectToAction("Index");
                }
                oldCategory.Name = category.Name;
                oldCategory.Description = category.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(int id, string confirm)
        {
            if (confirm == "Yes")
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return RedirectToAction("Index");
                }
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
