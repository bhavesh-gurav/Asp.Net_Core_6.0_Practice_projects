using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;

namespace MyWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        
        private IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ProductVM productVM = new ProductVM();
            productVM.Products = _unitOfWork.Product.GetAll();
            return View(productVM);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Category.Add(category);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Category Created Done...!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);

        //}


        //method for getting data from the database
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Category = _unitOfWork.Category.GetT(x => x.Id == id);
                if (vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
                
            }
        }

        //method to post data to unit of work
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {

            //Checking model state is valid or not it is server side validation.
            if (ModelState.IsValid)
            {
                //value is equals to 0 then it will create otherwise it will Update a records
                if(vm.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(vm.Category);
                    TempData["success"] = "Category Created Done...!";
                }
                else
                {
                    _unitOfWork.Category.Update(vm.Category);
                    TempData["success"] = "Category Updated Done...!";
                }
                
                _unitOfWork.Save();
                
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
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Done...!";
            return RedirectToAction("Index");

        }

    }
}
