using KolpackiRWypozyczalnia.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KolpackiRWypozyczalnia.Controllers
{
    public class FilmsController : Controller
    {
        FilmContext db;

        public FilmsController(FilmContext db)
        {
            this.db = db;
        }

        public IActionResult FilmsList(string categoryName)
        {
            var category = db.Categories.Include("Films").Where(c => c.Name.ToUpper()== categoryName.ToUpper()).Single();

            var films = category.Films.ToList();


            return View(films);
        }
            
    }
}
