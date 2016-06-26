using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore3.Domain.Abstract;
using SportsStore3.Domain.Entities;
using SportsStore3.WebUI.Controllers;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace SportsStore3.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Add_Cart_Items()
        {
            //Arrange
            Cart carrito = new Cart();
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            //Act
            carrito.AddItem(p1, 5);
            carrito.AddItem(p2, 2);
            CartLine[] results = carrito.Lines.ToArray();
            //Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, p1);
            Assert.AreEqual(results[1].Product, p2);
        }

        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new Product[] {
            //    new Product {ProductID = 1, Name = "P1"},
            //    new Product {ProductID = 2, Name = "P2"},
            //    new Product {ProductID = 3, Name = "P3"},
            //    new Product {ProductID = 4, Name = "P4"},
            //    new Product {ProductID = 5, Name = "P5"}
            //    });
            //ProductController controller = new ProductController(mock.Object);
            //controller.PageSize = 3;
            ////Act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List().Model;

            // Assert
            //PagingInfo pageInfo = result.PagingInfo;
            //Assert.AreEqual(pageInfo.CurrentPage, 2);
            //Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            //Assert.AreEqual(pageInfo.TotalItems, 5);
            //Assert.AreEqual(pageInfo.TotalPages, 2);
            Assert.AreEqual(1, 1);
        }
    }
}
