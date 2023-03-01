using System.Collections.Generic;
using System.Linq;

namespace Store.Models
{
    public sealed class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext m_context;

        public EFProductRepository(ApplicationDbContext context)
        {
            m_context = context;
        }

        public IQueryable<Product> Products => m_context.Products;
    }
}
