using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System.Security.Claims;

namespace MyWebApp.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claims != null)
            {
                if (HttpContext.Session.GetInt32("SessionCart") != null)
                {
                    return View(HttpContext.Session.GetInt32("SessionCart"));
                }
                else
                {
                    HttpContext.Session.SetInt32("SessionCart", _unitOfWork.Cart.GetAll(x => x.ApplicationUserId == claims.Value).ToList().Count);
                    return View(HttpContext.Session.GetInt32("SessionCart"));
                }
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
            
        }
    }
}
