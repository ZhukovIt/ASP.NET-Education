using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.Linq;
using Store.Models.ViewModels;

namespace Store.Controllers
{
    public sealed class ProductController : Controller
    {
        private IProductRepository m_repository;
        private int m_PageSize;

        public int PageSize
        {
            get
            {
                return m_PageSize;
            }

            set
            {
                m_PageSize = value;
            }
        }

        public ProductController(IProductRepository repository)
        {
            m_repository = repository;
            m_PageSize = 4;
        }

        public ViewResult List(int productPage = 1) =>
            View(
                new ProductsListViewModel
                {
                    Products = m_repository.Products
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = productPage,
                        ItemsPerPage = PageSize,
                        TotalItems = m_repository.Products.Count()
                    }
                }
            );
    }
}
