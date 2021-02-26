using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saidality.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController( AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Locaton> cl = new List<Locaton>();
            cl = (from c in _context.Locaton select c).ToList();
            cl.Insert(0, new Locaton { LocatonID = 0, State = "--Select State--" });
            ViewBag.message = cl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string BrandName, int LocatonID)
        {
            var result = (from c in _context.Stocks.Where(
                s => s.Mediciene.BrandName.Contains(BrandName) || s.Mediciene.ScientificName.Contains(BrandName))
                          select c)
                          .Include(s => s.Mediciene).Include(s => s.Pharmcy).Include(s=> s.Pharmcy.Locaton);

            //return Ok(result);
            if (result == null)
            {
                return NotFound();
            }
            //var viewModel = new HomeViewModel {
            //    Mediciene = result.ToList(),
            //    Pharmcy = result.ToList()
            //};

            //viewModel.Medicines = (IEnumerable<Medicine>)result;
            return View(await result.ToListAsync());
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
