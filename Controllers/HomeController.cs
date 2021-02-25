﻿using Microsoft.AspNetCore.Mvc;
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
            //var result = (from c in _auc.Medicines.Where(
            //    s => s.BrandName.Contains(BrandName) || s.ScientificName.Contains(BrandName))
            //              select c).ToList();

            var result = (from ep in _auc.Stocks
                          join e in _auc.Locaton on ep.StockID equals e.LocatonID 
                          join me in _auc.Medicines on ep.StockID equals me.MedicineID
                          join ph in _auc.Pharmcies on ep.StockID equals ph.PharmcyID
                          where e.LocatonID == LocatonID && ep.Mediciene.BrandName.Contains(BrandName) || ep.Mediciene.ScientificName.Contains(BrandName)
                          select new
                          {
                              medicineID= ep.Mediciene.MedicineID,
                              BrandName = ep.Mediciene.BrandName,
                              ScientificName= ep.Mediciene.ScientificName,
                              Type= ep.Mediciene.Type,
                              price= ep.Mediciene.Price,
                              pharmcies= ep.Pharmcy,
                              State = e.State,
                          }).Take(10);
            //return Ok(result);

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
