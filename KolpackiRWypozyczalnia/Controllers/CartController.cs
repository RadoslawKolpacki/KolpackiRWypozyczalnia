using KolpackiRWypozyczalnia.DAL;
using KolpackiRWypozyczalnia.Infrastracture;
using KolpackiRWypozyczalnia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;

namespace KolpackiRWypozyczalnia.Controllers
{
    public class CartController : Controller
    {

        FilmContext db;


        public CartController(FilmContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectAsJson<List<CartItem>>
                (HttpContext.Session, Const.CartKey);

            ViewBag.totalPrice = cart.Sum(i =>  i.Film.Price * i.Quantity);

            return View(cart);
        }
        public IActionResult Buy(int id) 
        {
            var film = db.Films.Find(id);
            if(SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Const.CartKey)==null)
            {
                var cart = new List<CartItem>();
                cart.Add(new CartItem
                {
                    Film = film,
                    Quantity = 1,
                    Value = film.Price
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, Const.CartKey, cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Const.CartKey);

                var index = GetIndex(id, cart);
                if (index == -1))
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
                    cart[index].Value = film.Price; 
                }
                
                SessionAuthentication.SetObjectAsJson<List<CartItem>>(HttpContext.Session, Const.CartKey, cart);
            }
            return RedirecttoAction("Index","Cart");   
            
        }
        bool ifExist(int id, List<CartItem>cartItems) 
        {
        for (int i = 0; i<cartItems.Count;i++)
            {
                if (cartItems[i].Film.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
