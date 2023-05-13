using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolpackiRWypozyczalnia.Models;

namespace KolpackiRWypozyczalnia.ViewModels
{
    public class AddFilmViewModel
    {
        public Film NewFilm { get; set; }

        public IFormFile Poster { get; set; }

        public List<Category> Categories { get; set; }
    }
}
