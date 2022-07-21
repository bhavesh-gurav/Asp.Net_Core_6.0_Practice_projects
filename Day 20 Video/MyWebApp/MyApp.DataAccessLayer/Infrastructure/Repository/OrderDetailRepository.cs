using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    internal class OrderDetailRepository : Repository<OrderDatail>, IOrderDetailRepository
    {

        private ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(OrderDatail orderDatail)
        {
            _context.OrderDatails.Update(orderDatail);


            //var categoryDB = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            //if(categoryDB != null)
            //{
            //    categoryDB.Name = category.Name;
            //    categoryDB.DisplayOrder = category.DisplayOrder;

            //}
        }
    }
}
