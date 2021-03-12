using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLJatko.Data;
using SQLJatko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLJatko.Controllers
{
    public class KotiController : Controller
    {
        // Tietokannalle oma muuttuja
        private SQLJatkoDb db;

        // Tietokannan tiedot lähetetään konstruktorissa Controllerin syntyessä
        // Eli otetaan referenssi SQLJatkoDb -tyyppiseen tietokantaan

        public KotiController(SQLJatkoDb _db)
        {
            db = _db;
        }

        public IActionResult Index([FromQuery] string year)
        {
            int yearFilter = year != null ? int.Parse(year) : 0;
            List<Game> games = db.Games.Where(game => game.ReleaseYear > yearFilter).ToList();
            return View(games);
        }

        [HttpGet]
        public IActionResult Luo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Luo(Game game)
        {
            if (!ModelState.IsValid)
            {
                return View("Luo");
            }
            db.Add(game);
            db.SaveChanges();
            return View("Success");
        }

    }
}
