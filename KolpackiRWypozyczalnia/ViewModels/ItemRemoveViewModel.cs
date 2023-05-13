using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class ItemRemoveViewModel
    {
        public int ItemId { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemValue { get; set; }

        public decimal TotalValue { get; set; }
    }
}
