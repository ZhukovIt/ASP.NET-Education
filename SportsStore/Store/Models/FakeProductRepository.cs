using System.Collections.Generic;
using System.Linq;

namespace Store.Models
{
    public sealed class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Футбольный мяч", Price = 249 },
            new Product { Name = "Доска для сёрфа", Price = 1499 },
            new Product { Name = "Кроссовки", Price = 3499 }
        }.AsQueryable();
    }
}
