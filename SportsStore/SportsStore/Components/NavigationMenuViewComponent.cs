using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.Models;

namespace SportsStore.Components
{
    public sealed class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository m_repository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            m_repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(m_repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
