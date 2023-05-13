using KolpackiRWypozyczalnia.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace KolpackiRWypozyczalnia.Infrastructure
{
    public static class CartManager
    {

        public static int RemoveFromCart(ISession session, int id)
        {
            var cart = GetItems(session);

            var thisFilm = cart.Find(i => i.Film.Id == id);
            var quantity = 0;

            if (thisFilm == null) return 0;

            if (thisFilm.Quantity > 1)
            {
                thisFilm.Quantity--;
                quantity = thisFilm.Quantity;
            }
            else
            {
                cart.Remove(thisFilm);
            }

            session.SetObjectAsJson(Consts.CartKey, cart);

            return quantity;
        }

        private static List<CartItem> GetItems(ISession session)
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

            return 0;
        }
    }
}
