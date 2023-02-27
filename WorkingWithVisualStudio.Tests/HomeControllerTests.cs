using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Организация
            HomeController controller = new HomeController();
            // Действие
            IEnumerable<Product> model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Утверждение
            Assert.Equal(SimpleRepository.SharedRepository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
