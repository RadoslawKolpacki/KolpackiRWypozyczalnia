using KolpackiRWypozyczalnia.Models;
using System.Collections.Generic;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class CategoryFilmsViewModel
    {
        public IEnumerable<Film> CategoryFilms { get; set; }
        public IEnumerable<Film> RecentFilms { get; set; }

        public Category Category { get; set; }
    }
}
