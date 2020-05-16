using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeinLiX.Models;

namespace MeinLiX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //TODO::
        public IActionResult Open_Organisations()
        {
            return RedirectToAction("Index", "Organisations");//+
        }

        public IActionResult Open_Subdivisions()
        {
            return RedirectToAction("Index", "Subdivisions");
        }

        public IActionResult Open_Players()
        {
            return RedirectToAction("Index", "Players");
        }

        public IActionResult Open_Games()
        {
            return RedirectToAction("Index", "Games");
        }

        public IActionResult Open_Sponsors()
        {
            return RedirectToAction("Index", "Sponsors");
        }

        public IActionResult Open_Events()
        {
            return RedirectToAction("Index", "Events");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
