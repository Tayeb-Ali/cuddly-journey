using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saidality.Models;

namespace Saidality.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Order.Include(o => o.Mediciene).Include(o => o.Person).Include(o => o.Pharmcy);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Mediciene)
                .Include(o => o.Person)
                .Include(o => o.Pharmcy)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["MedicieneId"] = new SelectList(_context.Medicines, "MedicineID", "BrandName");
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonID", "Name");
            ViewData["PharmacyId"] = new SelectList(_context.Pharmcies, "PharmcyID", "Name");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,PharmacyId,MedicieneId,PersonId,Location,Price,CreationDateTime,LastUpdateDateTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicieneId"] = new SelectList(_context.Medicines, "MedicineID", "BrandName", order.MedicieneId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonID", "Name", order.PersonId);
            ViewData["PharmacyId"] = new SelectList(_context.Pharmcies, "PharmcyID", "Name", order.PharmacyId);
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["MedicieneId"] = new SelectList(_context.Medicines, "MedicineID", "BrandName", order.MedicieneId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonID", "Name", order.PersonId);
            ViewData["PharmacyId"] = new SelectList(_context.Pharmcies, "PharmcyID", "Name", order.PharmacyId);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,PharmacyId,MedicieneId,PersonId,Location,Price,CreationDateTime,LastUpdateDateTime")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicieneId"] = new SelectList(_context.Medicines, "MedicineID", "BrandName", order.MedicieneId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonID", "Name", order.PersonId);
            ViewData["PharmacyId"] = new SelectList(_context.Pharmcies, "PharmcyID", "Name", order.PharmacyId);
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Mediciene)
                .Include(o => o.Person)
                .Include(o => o.Pharmcy)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}
