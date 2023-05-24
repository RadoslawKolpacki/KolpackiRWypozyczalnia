using KolpackiRWypozyczalnia.DAL;
using KolpackiRWypozyczalnia.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KolpackiRWypozyczalnia.Infrastructure
{
    public static class CartManager
    {
        public static void AddtoCart(ISession session, FilmsContext db, int filmId)
        {
            var cart = GetItems(session);
            var thisFilm = cart.Find(f => f.Film.Id == filmId);
            if (thisFilm != null)
            {
                thisFilm.Quantity++;
                thisFilm.Value += thisFilm.Film.Price;
            }
            else
            {
                var newCartItem = db.Films.Where(f => f.Id == filmId).SingleOrDefault();
                if (newCartItem != null)
                {
                    var cartItem = new CartItem
                    {
                        Film = newCartItem,
                        Quantity = 1,
                        Value = newCartItem.Price
                    };
                    cart.Add(cartItem);
                }
            }
            SessionHelper.SetObjectAsJson(session, Consts.CartKey, cart);
        }

        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(i => i.Film.Id == id);
            var quantity = 0;

            if (thisFilm == null) return 0;

            if (thisFilm.Quantity > 1)
            {
                thisFilm.Quantity--;
                thisFilm.Value -= thisFilm.Film.Price;
                quantity = thisFilm.Quantity;
            }
            else
            {
                cart.Remove(thisFilm);
            }

            session.SetObjectAsJson(Consts.CartKey, cart);

            return quantity;
        }

        public static List<CartItem> GetItems(ISession session)
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(session, Consts.CartKey);

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        internal static decimal GetCartValue(ISession session)
        {
            var cart = GetItems(session);
            return cart.Sum(i => i.Value);
        }

        /// <summary>
        /// TODO: pobieranie wartości pojedynczego itemu koszyka
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        internal static decimal GetItemValue(ISession session, int id)
        {
            var cart = GetItems(session);
            foreach (var item in cart)
            {
                if (id == item.Film.Id)
                {
                    return item.Value;
                }
            }
            return 0;
        }   
    }
}
