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
    public class LocatonController : Controller
    {
        private readonly AppDbContext _context;

        public LocatonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Locaton
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locaton.ToListAsync());
        }

        // GET: Locaton/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locaton = await _context.Locaton
                .FirstOrDefaultAsync(m => m.LocatonID == id);
            if (locaton == null)
            {
                return NotFound();
            }

            return View(locaton);
        }

        // GET: Locaton/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locaton/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocatonID,Country,State,NumberOfStreet,HomeNumber")] Locaton locaton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locaton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locaton);
        }

        // GET: Locaton/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locaton = await _context.Locaton.FindAsync(id);
            if (locaton == null)
            {
                return NotFound();
            }
            return View(locaton);
        }

        // POST: Locaton/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocatonID,Country,State,NumberOfStreet,HomeNumber")] Locaton locaton)
        {
            if (id != locaton.LocatonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locaton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocatonExists(locaton.LocatonID))
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
            return View(locaton);
        }

        // GET: Locaton/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locaton = await _context.Locaton
                .FirstOrDefaultAsync(m => m.LocatonID == id);
            if (locaton == null)
            {
                return NotFound();
            }

            return View(locaton);
        }

        // POST: Locaton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locaton = await _context.Locaton.FindAsync(id);
            _context.Locaton.Remove(locaton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatonExists(int id)
        {
            return _context.Locaton.Any(e => e.LocatonID == id);
        }
    }
}
