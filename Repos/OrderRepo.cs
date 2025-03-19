using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Storecd.Repos
{
    public class OrderRepo : Repository<Order>
    {
        public OrderRepo(MyDbContext context) : base(context) { }

        public List<Order> GetAllOrdersWithUsers()
        {
            using var context = new MyDbContext();

            var orders = context.Orders?
                .Include(o => o.IdUser)
                .Include(o => o.IdProduct)
                .ToList();

            return orders;
        }
    }
}