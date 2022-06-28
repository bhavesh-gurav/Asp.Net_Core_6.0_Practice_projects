 using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class CategoryController : Controller
    {

        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable <Category> categories = _context.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]     
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category Created Done...!";
                return RedirectToAction("Index");
            }
            return View(category);
            
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category Updated Done...!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category Deleted Done...!";
            return RedirectToAction("Index");

        }

    }
}
