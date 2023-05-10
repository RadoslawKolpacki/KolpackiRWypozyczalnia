using KolpackiRWypozyczalnia.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KolpackiRWypozyczalnia.Infrastracture
{
    public static class CartManager
    {
       public static int RemoveFromCart (ISession session, int id)
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
            session.SetObjectAsJson( Const.CartKey, cart);
            return quantity;
        
        }

        internal static decimal GetCartValue(ISession session)
        {
            var cart = GetItems (session);
            return cart.Sum(i => i.Value);
        }


        private static List<CartItem> GetItems(ISession session)
        {
        
            //throw new NotImplementedException();

            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Const.CartKey);

            if (cart == null)
            {
                cart => new List<CartItem>();
            }

            return cart;
        }

    }
}
