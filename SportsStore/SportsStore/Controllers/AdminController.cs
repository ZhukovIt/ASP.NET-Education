using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public sealed class AdminController : Controller
    {
        private IProductRepository m_repository;

        public AdminController(IProductRepository repository)
        {
            m_repository = repository;
        }

        public ViewResult Index() => View(m_repository.Products);

        public ViewResult Edit(int productId) =>
            View(m_repository.Products
                .FirstOrDefault(p => p.ProductID == productId));
    }
}
