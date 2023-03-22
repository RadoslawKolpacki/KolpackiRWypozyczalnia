using KolpackiRWypozyczalnia.DAL;
using KolpackiRWypozyczalnia.Models;
using KolpackiRWypozyczalnia.ViewModels;
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
            var model = new CategoryFilmsViewModel();

            var category = db.Categories.Include("Films").Where(c => c.Name.ToUpper()== categoryName.ToUpper()).Single();

            var films = category.Films.ToList();

            model.CategoryFilms = films;
            model.RecentFilms = db.Films.OrderByDescending(f => f.PublishDate).Take(3);
            model.Category = category;



            return View(model);
        }

        public IActionResult Details(int FilmId)
        {
            var category = db.Categories.Find(db.Films.Find(FilmId).CategoryId);
            var film = db.Films.Find(FilmId);

            

            return View(film);
        }
            
    }
}
