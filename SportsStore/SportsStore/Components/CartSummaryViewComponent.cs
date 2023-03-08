using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public sealed class CartSummaryViewComponent : ViewComponent
    {
        private Cart m_cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            m_cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(m_cart);
        }
    }
}
