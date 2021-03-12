using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLJatko.Controllers
{
    public class KotiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Testi()
        {
            return View();
        }

    }
}
