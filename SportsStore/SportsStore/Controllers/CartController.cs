using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public sealed class CartController : Controller
    {
        private IProductRepository m_repository;
        private Cart m_cart;

        public CartController(IProductRepository repository, Cart cartService)
        {
            m_repository = repository;
            m_cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = m_cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = m_repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                m_cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = m_repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                m_cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
