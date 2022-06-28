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

    }
}
