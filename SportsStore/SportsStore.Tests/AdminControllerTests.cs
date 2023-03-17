using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public sealed class AdminControllerTests
    {
        private Product[] m_Products = new Product[]
        {
            new Product { ProductID = 1, Name = "P1" },
            new Product { ProductID = 2, Name = "P2" },
            new Product { ProductID = 3, Name = "P3" }
        };

        [Fact]
        public void IndexContainsAllProducts()
        {
            // Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(m_Products.AsQueryable());
            // Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);
            // Действие
            Product[] result = GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();
            // Утверждение
            Assert.Equal(3, result.Length);
            Assert.Equal("P1", result[0].Name);
            Assert.Equal("P2", result[1].Name);
            Assert.Equal("P3", result[2].Name);
        }

        /// <summary>
        /// Метод для распаковки результата, возвращаемого методом действия,
        /// и получения данных модели представления.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
