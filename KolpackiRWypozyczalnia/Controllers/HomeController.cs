
using Flurl.Http.Content;
using KolpackiRWypozyczalnia.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KolpackiRWypozyczalnia.Controllers
{
    public class HomeController : Controller
    {
        FilmContext db;

        public HomeController(FilmContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var kategorie = db.Categories.ToList();

            return View(kategorie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}