using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolpackiRWypozyczalnia.DAL;
using KolpackiRWypozyczalnia.Infrastructure;
using KolpackiRWypozyczalnia.Models;
using KolpackiRWypozyczalnia.ViewModels;
using KolpackiRWypozyczalnia.Controllers;

namespace KolpackiRWypozyczalnia.Controllers
{
    public class CartController : Controller
    {
        FilmsContext db;

        public CartController(FilmsContext db)
        {
            this.db = db;
        }

        [Route("Koszyk")]
        public IActionResult Index()
        {
            var cart = CartManager.GetItems(HttpContext.Session);
            ViewBag.totalPrice = CartManager.GetCartValue(HttpContext.Session);
            return View(cart);
        }

        public IActionResult Buy(int id)
        {
            CartManager.AddtoCart(HttpContext.Session, db, id);
            return RedirectToAction("Index", "Cart");
        }


        public IActionResult RemoveFromCart(int id)
        {
            var model = new ItemRemoveViewModel()
            {
                ItemId = id,
                ItemQuantity = CartManager.RemoveFromCart(HttpContext.Session, id),
                ItemValue = CartManager.GetItemValue(HttpContext.Session, id),
                TotalValue = CartManager.GetCartValue(HttpContext.Session)
            };

            return Json(model);
        }
    }
}
