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


        [HttpPost]
        [Route("/search")]
        public string Search([FromBody] string content)
        {
            return content;
        }

        // POST: Locaton/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Search([Bind("LocatonID,Name")] string medicine)
        //{
            //return medicine;
            //if (ModelState.IsValid)
            //{
                 //await _auc.Medicines.Contains("")

                //_auc.Add(locaton);
                //await _auc.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            //}
           // return RedirectToAction(nameof(Index));
        //}

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
