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
        public ProductRepo(string connectionString) : base(connectionString) { }

        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll("Products");
        }

        public Product? GetProductById(int id)
        {
            return GetById("Products", id);
        }

        public void AddProduct(Product product)
        {
            Add("Products", product);
        }

        public void DeleteProduct(int id)
        {
            Delete("Products", id);
        }

        public List<Product> GetAllProductsWithCtegories()
        {
            using var context = new MyDbContext();

            var products = context.Products?
                .Include(p => p.IdCategoryNavigation).ToList();

            return products;
        }
    }
}