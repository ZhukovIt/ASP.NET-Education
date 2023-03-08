using SportsStore.Models;

namespace SportsStore.Models.ViewModels
{
    public sealed class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
