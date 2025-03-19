using Microsoft.EntityFrameworkCore;
using Moq;
using Store.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storecd.Repos
{
    public class RepositoryTest
    {
        private Mock<MyDbContext> _mockContext;
        private Mock<DbSet<Product>> _mockDbSet;
        private Repository<Product> _repository;

        public RepositoryTest()
        {
            var testProducts = new List<Product>
            {
                new Product { Id = 1, IdCategory = 1, IdRevew = 1, Name = "test1", Quantity = 5 },
                new Product { Id = 2, IdCategory = 2, IdRevew = 2, Name = "test2", Quantity = 15 }
            }.AsQueryable();

            _mockDbSet = new Mock<DbSet<Product>>();
            _mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(testProducts.Provider);
            _mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(testProducts.Expression);
            _mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(testProducts.ElementType);
            _mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(testProducts.GetEnumerator());

            _mockContext = new Mock<MyDbContext>();
            _mockContext.Setup(c => c.Set<Product>()).Returns(_mockDbSet.Object);

            _repository = new Repository<Product>(_mockContext.Object);
        }

        [Fact]
        public void GetAllReturns_AllProducts()
        {
            var products = _repository.GetAll();

            Assert.Equal(2, products.Count());
        }

        [Fact]
        public void GetById_ReturnsCorrectProduct()
        {
            _mockDbSet.Setup(m => m.Find(1)).Returns(new Product { Id = 1, Name = "test1", Quantity = 5 });

            var product = _repository.GetId(1);

            Assert.NotNull(product);
            Assert.Equal("test1", product.Name);
        }

        [Fact]
        public void Add_AddsProductToDB()
        {
            var newProduct = new Product { Id = 3, Name = "test3", Quantity = 30 };

            _repository.Add(newProduct);

            _mockDbSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Remove_RemovesProductFromDB()
        {
            var removingProduct = new Product { Id = 1, Name = "test1", Quantity = 5 };

            _repository.Delete(removingProduct.Id);

            _mockDbSet.Verify(m => m.Remove(It.IsAny<Product>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}