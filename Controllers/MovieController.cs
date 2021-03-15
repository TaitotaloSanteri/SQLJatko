using Microsoft.AspNetCore.Mvc;
using SQLJatko.Data;
using SQLJatko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLJatko.Controllers
{
    public class MovieController : Controller
    {
        // Tietokannalle oma muuttuja
        private SQLJatkoDb db;

        // Tietokannan tiedot lähetetään konstruktorissa Controllerin syntyessä
        // Eli otetaan referenssi SQLJatkoDb -tyyppiseen tietokantaan

        public MovieController(SQLJatkoDb _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            List<Movie> movies = db.Movies.ToList();
            return View(movies);
            // return Views/Movie/Index.cshtml
        }

        [HttpGet]
        public IActionResult Luo()
        {
            return View();
            // return Views/Movie/Luo.cshtml
        }

        [HttpPost]
        public IActionResult Luo(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("Luo");
            }
            db.Movies.Add(movie);
            db.SaveChanges();
            return View("Success");
        }

    }
}
