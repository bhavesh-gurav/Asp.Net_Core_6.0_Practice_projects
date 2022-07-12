using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        //Make propeties in wrapper class
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        ICartRepository Cart { get; }

        IApplicationUser ApplicationUser { get; }
        void Save();
    }
}
