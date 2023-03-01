using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using System;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Организация
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            HomeController controller = new HomeController { Repository = mock.Object };
            // Действие
            IEnumerable<Product> model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Утверждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Организация
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(new Product[] { new Product { Name = "P1", Price = 100 } });
            HomeController controller = new HomeController { Repository = mock.Object };
            // Действие
            IActionResult result = controller.Index();
            // Утверждение
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
