using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    // This is bundle to access all classes and functions
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _context;

        //Declared IRepositories
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public ICartRepository Cart { get; private set; }

        public IApplicationUser ApplicationUser { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            //Register those repo here...
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            Cart = new CartRepository(context);
            ApplicationUser = new ApplicationUserRepository(context);
            OrderHeader = new OrderHeaderRepository(context);
            OrderDetail = new OrderDetailRepository(context);
        }

        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
