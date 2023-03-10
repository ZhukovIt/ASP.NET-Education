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
