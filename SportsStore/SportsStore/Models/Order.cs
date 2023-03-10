using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{
    public sealed class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите первую строку Вашего адреса")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название Вашей страны")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название Вашего города")]
        public string City { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название Вашего региона / области / штата")]
        public string Region { get; set; }

        public string Zip { get; set; }

        public bool GiftWrap { get; set; }
    }
}
