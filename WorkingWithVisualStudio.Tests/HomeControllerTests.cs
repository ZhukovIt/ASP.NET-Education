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
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Организация
            HomeController controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository
            {
                Products = products
            };
            // Действие
            IEnumerable<Product> model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Утверждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyCounter { get; set; } = 0;

            public IEnumerable<Product> Products
            {
                get
                {
                    PropertyCounter++;
                    return new[] { new Product { Name = "P1", Price = 100 } };
                }
            }

            public void AddProduct(Product p)
            {
                // Метод ничего не делает, так как для теста это не требуется
            }

            public void RepositoryPropertyCalledOnce()
            {
                // Организация
                PropertyOnceFakeRepository repo = new PropertyOnceFakeRepository();
                HomeController controller = new HomeController { Repository = repo };
                // Действие
                IActionResult result = controller.Index();
                // Утверждение
                Assert.Equal(1, repo.PropertyCounter);
            }
        }
    }
}
