using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public sealed class NavigationMenuViewComponentTests
    {
        private Product[] m_Products = new Product[]
        {
            new Product { ProductID = 1, Name = "P1", Category = "Апельсины" },
            new Product { ProductID = 2, Name = "P2", Category = "Яблоки" },
            new Product { ProductID = 3, Name = "P3", Category = "Яблоки" },
            new Product { ProductID = 4, Name = "P4", Category = "Сливы" }
        };

        [Fact]
        public void CanSelectCategories()
        {
            // Организация
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(m_Products.AsQueryable());
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            // Действие - получение набора категорий
            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult)
                .ViewData.Model).ToArray();
            // Утверждение
            Assert.True(Enumerable.SequenceEqual(new string[]
                {
                    "Апельсины",
                    "Сливы",
                    "Яблоки"
                }, results));
        }

        [Fact]
        public void IndicatesSelectedCategory()
        {
            // Организация
            string categoryToSelect = "Яблоки";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(m_Products.AsQueryable());
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;
            // Действие
            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];
            // Утверждение
            Assert.Equal(categoryToSelect, result);
        }
    }
}
