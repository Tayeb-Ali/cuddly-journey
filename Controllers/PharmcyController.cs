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
    public class PharmcyController : Controller
    {
        private readonly AppDbContext _context;

        public PharmcyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pharmcy
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pharmcies.Include(p => p.Locaton);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Pharmcy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmcy = await _context.Pharmcies
                .Include(p => p.Locaton)
                .FirstOrDefaultAsync(m => m.PharmcyID == id);
            if (pharmcy == null)
            {
                return NotFound();
            }

            return View(pharmcy);
        }

        // GET: Pharmcy/Create
        public IActionResult Create()
        {
            ViewData["LocatonID"] = new SelectList(_context.Locaton, "LocatonID", "State");
            return View();
        }

        // POST: Pharmcy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PharmcyID,Name,LocatonID,CreationDateTime,LastUpdateDateTime")] Pharmcy pharmcy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmcy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocatonID"] = new SelectList(_context.Locaton, "LocatonID", "State", pharmcy.LocatonID);
            return View(pharmcy);
        }

        // GET: Pharmcy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmcy = await _context.Pharmcies.FindAsync(id);
            if (pharmcy == null)
            {
                return NotFound();
            }
            ViewData["LocatonID"] = new SelectList(_context.Locaton, "LocatonID", "State", pharmcy.LocatonID);
            return View(pharmcy);
        }

        // POST: Pharmcy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PharmcyID,Name,LocatonID,CreationDateTime,LastUpdateDateTime")] Pharmcy pharmcy)
        {
            if (id != pharmcy.PharmcyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmcy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmcyExists(pharmcy.PharmcyID))
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
            ViewData["LocatonID"] = new SelectList(_context.Locaton, "LocatonID", "State", pharmcy.LocatonID);
            return View(pharmcy);
        }

        // GET: Pharmcy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmcy = await _context.Pharmcies
                .Include(p => p.Locaton)
                .FirstOrDefaultAsync(m => m.PharmcyID == id);
            if (pharmcy == null)
            {
                return NotFound();
            }

            return View(pharmcy);
        }

        // POST: Pharmcy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmcy = await _context.Pharmcies.FindAsync(id);
            _context.Pharmcies.Remove(pharmcy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmcyExists(int id)
        {
            return _context.Pharmcies.Any(e => e.PharmcyID == id);
        }
    }
}
