using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITI_Project.Context;

namespace ITI_Project.Controllers
{
    public class ProductController : Controller
    {
        ProductContext db = new ProductContext();

        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).ToList();
            return View(products);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (string.IsNullOrEmpty(product.ImagePath))
            {
                product.ImagePath = "/images/default.png";
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Are Required");
                ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(product);
            }

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(product);
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (string.IsNullOrEmpty(product.ImagePath))
            {
                product.ImagePath = "/images/default.png";
            }

            if (ModelState.IsValid)
            {
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
    }
}