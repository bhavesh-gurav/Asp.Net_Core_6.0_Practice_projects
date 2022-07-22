using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICartRepository:IRepository<Cart>
    {

        int IncrementCartItem(Cart cart, int count);
        int DecrementCartItem(Cart cart, int count);
    }
}
