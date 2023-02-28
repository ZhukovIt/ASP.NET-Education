using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                // Метод ничего не делает, так как этого не требуется для теста
            }
        }

        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]
        public void IndexActionModelIsComplete(decimal first, decimal second, decimal third, decimal fourth)
        {
            // Организация
            HomeController controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository
            {
                Products = new Product[]
                {
                    new Product { Name = "P1", Price = first },
                    new Product { Name = "P2", Price = second },
                    new Product { Name = "P3", Price = third },
                    new Product { Name = "P4", Price = fourth }
                }
            };
            // Действие
            IEnumerable<Product> model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Утверждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
