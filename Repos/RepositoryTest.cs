using Microsoft.EntityFrameworkCore;
using Moq;
using Store.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace Storecd.Repos
{
    public class RepositoryTest
    {
        private Mock<IDbConnection> _mockDbConnection = new Mock<IDbConnection>();
        private Repository<Product> _repository;

        public RepositoryTest()
        {
            _mockDbConnection = new Mock<IDbConnection>();

            _mockDbConnection.Setup(db => db.Execute(It.IsAny<string>(), It.IsAny<object>(), null, null, null))
                    .Returns(1);

            _repository = new Repository<Product>(_mockDbConnection.Object);
        }

        [Fact]
        public void GetAllReturns_AllProducts()
        {
            var products = _repository.GetAll("Products");

            Assert.Equal(2, products.Count());
        }

        [Fact]
        public void GetById_ReturnsCorrectProduct()
        {
            _mockDbConnection
                .Setup(m => m.QuerySingleOrDefault<Product>("SELECT * FROM Products WHERE Id = @Id", It.IsAny<object>(), null, null, null))
                .Returns(new Product { Id = 1, Name = "test1", Quantity = 5 });

            var product = _repository.GetById("Product", 1);

            Assert.NotNull(product);
            Assert.Equal("test1", product.Name);
        }

        [Fact]
        public void Add_AddsProductToDB()
        {
            var newProduct = new Product { Id = 3, Name = "test3", Quantity = 30 };

            _repository.Add("Products",newProduct);

            _mockDbConnection.Verify(db => db.Execute("INSERT INTO Products VALUES (@Id, @Name, @Quantity)", It.IsAny<object>(), null, null, null), Times.Once);
        }

        [Fact]
        public void Remove_RemovesProductFromDB()
        {
            var removingProduct = new Product { Id = 1, Name = "test1", Quantity = 5 };

            _repository.Delete("Products", removingProduct.Id);

            _mockDbConnection.Verify(db => db.Execute("INSERT INTO Products VALUES (@Id, @Name, @Quantity)", It.IsAny<object>(), null, null, null), Times.Once);
        }
    }
}