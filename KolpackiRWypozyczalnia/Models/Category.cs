using KolpackiRWypozyczalnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.Models
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}
