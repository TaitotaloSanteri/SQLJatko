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

        public IActionResult Index()
        {
            List<Game> games = db.Games.ToList();
            return View(games);
            // return Views/Koti/Index.cshtml
        }

        [HttpGet]
        public IActionResult Luo()
        {
            return View();
            // return Views/Koti/Luo.cshtml
        }

        [HttpPost]
        public IActionResult IndexFilter(int minYear, int maxYear, string gameName, Genre gameGenre, Platform gamePlatform)
        {
            IEnumerable<Game> games = db.Games;

            if (minYear > 0 && maxYear >= minYear)
            {
                games = games.Where(game => game.ReleaseYear >= minYear && game.ReleaseYear <= maxYear);
            }

            if (!String.IsNullOrEmpty(gameName))
            {
                games = games.Where(game => game.GameName.Contains(gameName));
            }

            if (gameGenre != 0)
            {
                games = games.Where(game => game.GameGenre == gameGenre);
            }

            if (gamePlatform != 0)
            {
                games = games.Where(game => game.GamePlatform == gamePlatform);
            }

            games = games.ToList();

            return View("Index", games);
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            Game gameToUpdate = db.Games.Find(id);
            return View(gameToUpdate);
            //return Views/Koti/Update.cshtml
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Game gameToDelete = db.Games.Find(id);
            return View(gameToDelete);
            //return Views/Koti/Delete.cshtml
        }

        [HttpGet]
        public IActionResult DeletePost(int id)
        {
            Game gameToDelete = db.Games.Find(id);
            db.Games.Remove(gameToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAll()
        {
            IEnumerable<Game> games = db.Games;
            foreach (Game game in games)
            {
                db.Games.Remove(game);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePost(Game gameToUpdate)
        {
            db.Games.Update(gameToUpdate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
