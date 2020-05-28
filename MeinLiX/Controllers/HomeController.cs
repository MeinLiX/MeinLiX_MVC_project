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
#pragma warning disable IDE0052 // Remove unread private members
        private readonly ILogger<HomeController> _logger;
#pragma warning restore IDE0052 // Remove unread private members

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

        public IActionResult Roles()
        {
            return RedirectToAction("Index", "Roles");
        }
        public IActionResult Users()
        {
            return RedirectToAction("Index", "Users");
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
