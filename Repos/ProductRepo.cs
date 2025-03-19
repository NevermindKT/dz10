using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Storecd.Repos
{
    public class ProductRepo : Repository<Product>
    {
        public ProductRepo(MyDbContext context) : base(context) { }

        public List<Product> GetAllProductsWithCtegories()
        {
            using var context = new MyDbContext();

            var products = context.Products?
                .Include(p => p.IdCategory).ToList();

            return products;
        }
    }
}