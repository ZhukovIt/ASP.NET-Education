using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public sealed class ProductController : Controller
    {
        private IProductRepository m_repository;

        public ProductController(IProductRepository repository)
        {
            m_repository = repository;
        }

        public ViewResult List() => View(m_repository.Products);
    }
}
