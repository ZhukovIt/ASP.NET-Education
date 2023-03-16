using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public sealed class OrderController : Controller
    {
        private IOrderRepository m_repository;
        private Cart m_Cart;

        public OrderController(IOrderRepository repository, Cart cartService)
        {
            m_repository = repository;
            m_Cart = cartService;
        }

        public ViewResult List() =>
            View(m_repository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = m_repository.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                m_repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (m_Cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, но Ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = m_Cart.Lines.ToArray();
                m_repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            m_Cart.Clear();
            return View();
        }
    }
}
