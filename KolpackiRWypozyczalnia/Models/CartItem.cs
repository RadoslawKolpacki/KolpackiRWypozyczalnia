using KolpackiRWypozyczalnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.Models
{
    public class CartItem
    {
        public Film Film { get; set; }

        public int Quantity { get; set; }

        public decimal Value { get; set; }
    }
}
