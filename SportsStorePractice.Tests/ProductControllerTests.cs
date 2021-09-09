using Moq;
using SportsStorePractice.Controllers;
using SportsStorePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportsStorePractice.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate() {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"},
                new Product {ProductID = 6, Name = "P6"},
                new Product {ProductID = 7, Name = "P7"},
                new Product {ProductID = 8, Name = "P8"},
                new Product {ProductID = 9, Name = "P9"}
            }).AsQueryable<Product>());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            IEnumerable<Product> result = 
                controller.List(3).ViewData.Model as IEnumerable<Product>;
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 3);
            Assert.Equal("P7", prodArray[0].Name);
            Assert.Equal("P8", prodArray[1].Name);
        }
    }
}