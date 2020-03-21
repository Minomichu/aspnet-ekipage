using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ekipage.Data;
using ekipage.Models;

namespace ekipage.Controllers
{
    public class RiderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RiderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rider
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rider.Include(r => r.Horse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rider/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rider = await _context.Rider
                .Include(r => r.Horse)
                .FirstOrDefaultAsync(m => m.RiderId == id);
            if (rider == null)
            {
                return NotFound();
            }

            return View(rider);
        }

        // GET: Rider/Create
        public IActionResult Create()
        {
            ViewData["HorseId"] = new SelectList(_context.Horse, "HorseId", "HorseName");
            return View();
        }

        // POST: Rider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RiderId,RiderName,Preference,HorseId")] Rider rider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HorseId"] = new SelectList(_context.Horse, "HorseId", "HorseName", rider.HorseId);
            return View(rider);
        }

        // GET: Rider/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rider = await _context.Rider.FindAsync(id);
            if (rider == null)
            {
                return NotFound();
            }
            ViewData["HorseId"] = new SelectList(_context.Horse, "HorseId", "HorseName", rider.HorseId);
            return View(rider);
        }

        // POST: Rider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RiderId,RiderName,Preference,HorseId")] Rider rider)
        {
            if (id != rider.RiderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiderExists(rider.RiderId))
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
            ViewData["HorseId"] = new SelectList(_context.Horse, "HorseId", "HorseName", rider.HorseId);
            return View(rider);
        }

        // GET: Rider/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rider = await _context.Rider
                .Include(r => r.Horse)
                .FirstOrDefaultAsync(m => m.RiderId == id);
            if (rider == null)
            {
                return NotFound();
            }

            return View(rider);
        }

        // POST: Rider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rider = await _context.Rider.FindAsync(id);
            _context.Rider.Remove(rider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiderExists(int id)
        {
            return _context.Rider.Any(e => e.RiderId == id);
        }
    }
}
