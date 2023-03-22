using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models {

    public class Product {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите наименование товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите описание товара")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Пожалуйста, введите положительное значение для цены товара")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите категорию товара")]
        public string Category { get; set; }
    }
}
