using System.Collections.Generic;
using Store.Models;

namespace Store.Models.ViewModels
{
    public sealed class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
