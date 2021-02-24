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

        private MySqlConnection GetConnection()
        {
            string mySqlConnectionStr = "server=localhost;port=3306;database=PharmacyDb;user=root;password=''";

            return new MySqlConnection(mySqlConnectionStr);
        }
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
            var result = (from c in _auc.Medicines.Where(s => s.BrandName.Contains(BrandName)) select c).ToList();

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
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
