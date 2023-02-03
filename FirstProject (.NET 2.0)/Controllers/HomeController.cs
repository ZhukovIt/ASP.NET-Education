using System;
using PartyInvites.Models;
using Microsoft.AspNetCore.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            if (hour > 6 && hour < 12)
            {
                ViewBag.Greeting = "Доброе утро";
            }
            else if (hour >= 12 && hour < 17)
            {
                ViewBag.Greeting = "Добрый день";
            }
            else if (hour >= 17 && hour < 22)
            {
                ViewBag.Greeting = "Добрый вечер";
            }
            else
            {
                ViewBag.Greeting = "Доброй ночи";
            }
            
            return View("MyView");
        }

        [HttpGet]
        public ViewResult FormGoParty()
        {
            return View();
        }

        [HttpPost]
        public ViewResult FormGoParty(GuestResponse guestResponse)
        {
            Repository.AddGuestResponse(guestResponse);
            return View("Thanks", guestResponse);
        }
    }
}