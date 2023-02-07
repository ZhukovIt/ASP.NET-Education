using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product[] array =
            {
                new Product { Name = "Kayak", Price = 275M},
                new Product { Name = "Lifejacket", Price = 48.95M},
                new Product { Name = "Soccer ball", Price = 19.50M},
                new Product { Name = "Corner flag", Price = 34.95M}
            };

            return View(array);
        }
    }
}
