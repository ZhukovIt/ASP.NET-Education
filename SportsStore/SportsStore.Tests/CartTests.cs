using System.Linq;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public sealed class CartTests
    {
        // Организация - общие данные товаров
        private Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100 };
        private Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50 };
        private Product p3 = new Product { ProductID = 3, Name = "P3", Price = 25 };

        [Fact]
        public void CanAddNewLines()
        {
            // Организация
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            // Действие
            CartLine[] results = target.Lines.ToArray();
            // Утверждение
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }

        [Fact]
        public void CanAddQuantityForExistingLines()
        {
            // Организация
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            // Действие
            CartLine[] results = target.Lines
                .OrderBy(c => c.Product.ProductID).ToArray();
            // Утверждение
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public void CanRemoveLine()
        {
            // Организация
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);
            // Действие
            target.RemoveLine(p2);
            // Утверждение
            Assert.Equal(0, target.Lines.Where(c => c.Product == p2).Count());
            Assert.Equal(2, target.Lines.Count());
        }

        [Fact]
        public void CalculateCartTotal()
        {
            // Организация
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            // Действие
            decimal result = target.ComputeTotalValue();
            // Утверждение
            Assert.Equal(450M, result);
        }

        [Fact]
        public void CanClearContents()
        {
            // Организация
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            // Действие
            target.Clear();
            // Утверждение
            Assert.Equal(0, target.Lines.Count());
        }
    }
}
