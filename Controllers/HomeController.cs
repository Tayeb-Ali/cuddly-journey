using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Saidality.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _auc;

        public HomeController(ILogger<HomeController> logger, AppDbContext aus)
        {
            _logger = logger;
            _auc = aus;
        }

        public IActionResult Index()
        {
            List<Locaton> cl = new List<Locaton>();
            cl = (from c in _auc.Locaton select c).ToList();
            cl.Insert(0, new Locaton { LocatonID = 0, State = "--Select State--" });
            ViewBag.message = cl;
            return View();
        }

        public IActionResult Search()
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
