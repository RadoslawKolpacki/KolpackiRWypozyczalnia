﻿using KolpackiRWypozyczalnia.DAL;
using KolpackiRWypozyczalnia.Models;
using KolpackiRWypozyczalnia.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace KolpackiRWypozyczalnia.Controllers
{
    public class FilmsController : Controller
    {
        FilmContext db;
        IWebHostEnvironment hostEnvironment;

        public FilmsController(FilmContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this.hostEnvironment = hostEnvironment;
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
            //var category = db.Categories.Find(db.Films.Find(FilmId).CategoryId);
            //var film = db.Films.Find(FilmId);

            var film = db.Films.Include("Category").Where(f=> f.Id == FilmId).Single();


            return View(film);
        }
        [HttpGet]
        public IActionResult AddFilm()
        {
            var model = new AddFilmViewModel();
            var catergories = db.Categories.ToList();  
            
            return View();
        }
        [HttpPost]
        public IActionResult AddFilm(AddFilmViewModel model)
        {
            var folderPath = Path.Combine(hostEnvironment.WebRootPath, "content");
            var uniqueName = model.Poster.FileName + Guid.NewGuid();
            var posterPath = Path.Combine(folderPath, uniqueName);

            model.Poster.CopyTo(new FileStream(posterPath, FileMode.Create));

            model.NewFilm.PublishDate = DateTime.Now;
            model.NewFilm.PosterName = uniqueName;

            db.Films.Add(model.NewFilm);

            db.SaveChanges();  
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Search (String text)
        {

            var films = from f in db.Films select f;

            if(!String.IsNullOrEmpty(text))
            {
                films = films.Where(f=>f.Title.Contains(text));

                return View(films.ToList());
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
