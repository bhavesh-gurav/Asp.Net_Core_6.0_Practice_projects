using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class ProductVM
    {

        public Product Product { get; set; } = new Product();

        //This is view model for controller
        [ValidateNever]
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
