using KolpackiRWypozyczalnia.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class AddFilmViewModel
    {
        public Film NewFilm { get; set; }

        public List<Category> Categories { get; set; }

        public IFormFile Poster { get; set; }
    }
}
