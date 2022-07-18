using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System.Security.Claims;

namespace MyWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region APICALL
        public IActionResult AllOrders()
        {
            IEnumerable<OrderHeader> orderHeaders;

            if (User.IsInRole("Admin") || User.IsInRole("Employee"))
            {
                orderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            }
            else
            {
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
                orderHeaders = _unitOfWork.OrderHeader.GetAll(x => x.ApplicationUserId == claims.Value);
            }
            
            return Json(new { data = orderHeaders });
        }
        #endregion

        public IActionResult Index()
        {

            return View();
        }
    }
}
