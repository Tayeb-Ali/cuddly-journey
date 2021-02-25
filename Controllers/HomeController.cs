using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Saidality.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
        public async Task<IActionResult> Search(string BrandName, int LocatonID)
        {
            var result = (from c in _auc.Medicines.Where(
                s => s.BrandName.Contains(BrandName)|| s.ScientificName.Contains(BrandName)) select c).ToList();

            //var entryPoint = (from ep in _auc.Locaton
            //                  join e in _auc.Medicines on ep.LocatonID equals e.MedicineID
            //                  where e.OwnerID == user.UID
            //                  select new
            //                  {
            //                      UID = e.OwnerID,
            //                      TID = e.TID,
            //                      Title = t.Title,
            //                      EID = e.EID
            //                  }).Take(10);


            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
            
        
        public IActionResult Admin()
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
