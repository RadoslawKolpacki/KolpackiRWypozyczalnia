using KolpackiRWypozyczalnia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class CategoryFilmsViewModel
    {
        public IEnumerable<Film> CategoryFilms { get; set; }
        public IEnumerable<Film> RecentFilms { get; set; }

        public Category Category { get; set; }
    }
}
