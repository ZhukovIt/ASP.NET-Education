﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SportsStore.Controllers
{
    [Authorize]
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

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                m_repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} был сохранён";
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = m_repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} был удалён";
            }
            return RedirectToAction("Index");
        }
    }
}
