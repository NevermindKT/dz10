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
        public OrderRepo(string connectionString) : base(connectionString) { }

        public IEnumerable<Order> GetAllProducts()
        {
            return GetAll("Orders");
        }

        public Order? GetProductById(int id)
        {
            return GetById("Orders", id);
        }

        public void AddOrder(Order order)
        {
            Add("Orders", order);
        }

        public void DeleteProduct(int id)
        {
            Delete("Orders", id);
        }

        public List<Order> GetAllOrdersWithUsers()
        {
            using var context = new MyDbContext();

            var orders = context.Orders?
                .Include(o => o.IdUserNavigation)
                .Include(o => o.IdProductNavigation)
                .ToList();

            return orders;
        }
    }
}