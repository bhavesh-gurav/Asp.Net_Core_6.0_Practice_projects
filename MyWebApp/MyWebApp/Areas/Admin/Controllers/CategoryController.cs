using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;

namespace MyWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]  //When form is submited the it generate token XSS prevent from this attack.
        //public IActionResult Create(Category category)
        //{
        //    // Server Side Validation
        //    if (ModelState.IsValid)  //If your model's all value are right to set then is valid.
        //    {
        //        _unitOfWork.Category.Add(category);
        //        _unitOfWork.Save();
                
        //        // Tempddata is work on one request then it will destroy for next request.
        //        TempData["success"] = "Category Created Done...";
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}


        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            Category category = new Category();
            if (id == null || id == 0)
            {
                return View(category);
            }
            else
            {
                //var category = _unitOfWork.Category.GetT(x => x.Id == id);
                //if (category == null)
                //{
                //    return NotFound();
                //}
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //When form is submited the it generate token XSS prevent from this attack.
        public IActionResult Edit(Category category)
        {
            // Server Side Validation
            if (ModelState.IsValid)  //If your model's all value are right to set then is valid.
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Done...";
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
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]  //When form is submited the it generate token XSS prevent from this attack.
        public IActionResult DeleteData(int? id)
        {

            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Done...";
            return RedirectToAction("Index");
        }


    }
}
