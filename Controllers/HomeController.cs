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
        public async Task<IActionResult> Create(string BrandName, int LocatonID)
        {
            if (LocatonID == null)
            {
                return NotFound();
            }

            var medicine = await _auc.Medicines
                .FirstOrDefaultAsync(m => m.BrandName.Contains(BrandName));
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }


        //[HttpPost]
        //[Route("Home/search")]
        //public IActionResult Search(string BrandName, int LocatonID)
        //{
        //    List<Medicine> list = new List<Medicine>();

        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select * from Medicines where MedicineID ="+ LocatonID, conn);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new Medicine()
        //                {
        //                    MedicineID = Convert.ToInt32(reader["MedicineID"]),
        //                    BrandName = reader["BrandName"].ToString(),
        //                    ScientificName = reader["ScientificName"].ToString(),
        //                    Price = Convert.ToInt32(reader["Price"]),
        //                });
        //            }
        //        }
        //    }
        //    return View(list);
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
