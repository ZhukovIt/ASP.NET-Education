using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

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
    }
}
