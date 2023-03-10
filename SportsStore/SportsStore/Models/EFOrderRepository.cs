using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SportsStore.Models
{
    public sealed class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext m_context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            m_context = context;
        }

        public IQueryable<Order> Orders => m_context.Orders
            .Include(order => order.Lines)
            .ThenInclude(line => line.Product);

        public void SaveOrder(Order order)
        {
            m_context.AttachRange(order.Lines.Select(line => line.Product));
            if (order.OrderID == 0)
            {
                m_context.Orders.Add(order);
            }
            m_context.SaveChanges();
        }
    }
}
