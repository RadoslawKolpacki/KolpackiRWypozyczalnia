using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolpackiRWypozyczalnia.DAL;
using KolpackiRWypozyczalnia.Infrastructure;
using KolpackiRWypozyczalnia.Models;
using KolpackiRWypozyczalnia.ViewModels;

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
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartKey);

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            ViewBag.totalPrice = cart.Sum(i => i.Value);
            return View(cart);
        }

        public IActionResult Buy(int id)
        {
            var film = db.Films.Find(id);

            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartKey) == null)
            {
                var cart = new List<CartItem>();
                cart.Add(new CartItem
                {
                    Film = film,
                    Quantity = 1,
                    Value = film.Price
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartKey, cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartKey);

                var index = GetIndex(id, cart);
                if (index == -1)
                {
                    cart.Add(new CartItem
                    {
                        Film = film,
                        Quantity = 1,
                        Value = film.Price
                    });
                }
                else
                {
                    cart[index].Quantity++;
                    cart[index].Value += film.Price;
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.CartKey, cart);
            }

            return RedirectToAction("Index", "Cart");
        }

        int GetIndex(int id, List<CartItem> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Film.Id == id)
                {
                    return i;
                }
            }

            return -1;
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
