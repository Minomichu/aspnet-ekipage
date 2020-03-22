using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ekipage.Data;
using ekipage.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authorization;

namespace ekipage.Controllers
{
    public class DateForLessonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DateForLessonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DateForLesson
        public async Task<IActionResult> Index()
        {

            var hest = _context.Rider
                .FromSqlRaw("SELECT * FROM Rider") //INNER JOIN Horse ON Rider.HorseId = Horse.HorseId")
                .ToList();

            ViewBag.text = hest;
            
            /*
            var hest = (from h in _context.Horse
                        select h).ToList();

            ViewBag.text = hest;
            */

            /*
            IQueryable<Horse> Hest =
                from hejhej in _context.Horse select hejhej;

            ViewBag.text = Hest.ToList();
            */

            var applicationDbContext = _context.DateForLesson.Include(d => d.LessonContent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DateForLesson/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dateForLesson = await _context.DateForLesson
                .Include(d => d.LessonContent)
                .FirstOrDefaultAsync(m => m.DateForLessonId == id);
            if (dateForLesson == null)
            {
                return NotFound();
            }

            return View(dateForLesson);
        }

        // GET: DateForLesson/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["LessonContentId"] = new SelectList(_context.LessonContent, "LessonContentId", "Lesson");
            return View();
        }

        // POST: DateForLesson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateForLessonId,Date,LessonContentId")] DateForLesson dateForLesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dateForLesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonContentId"] = new SelectList(_context.LessonContent, "LessonContentId", "Lesson", dateForLesson.LessonContentId);
            return View(dateForLesson);
        }

        // GET: DateForLesson/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dateForLesson = await _context.DateForLesson.FindAsync(id);
            if (dateForLesson == null)
            {
                return NotFound();
            }
            ViewData["LessonContentId"] = new SelectList(_context.LessonContent, "LessonContentId", "Lesson", dateForLesson.LessonContentId);
            return View(dateForLesson);
        }

        // POST: DateForLesson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("DateForLessonId,Date,LessonContentId")] DateForLesson dateForLesson)
        {
            if (id != dateForLesson.DateForLessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dateForLesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateForLessonExists(dateForLesson.DateForLessonId))
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
            ViewData["LessonContentId"] = new SelectList(_context.LessonContent, "LessonContentId", "Lesson", dateForLesson.LessonContentId);
            return View(dateForLesson);
        }

        // GET: DateForLesson/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dateForLesson = await _context.DateForLesson
                .Include(d => d.LessonContent)
                .FirstOrDefaultAsync(m => m.DateForLessonId == id);
            if (dateForLesson == null)
            {
                return NotFound();
            }

            return View(dateForLesson);
        }

        // POST: DateForLesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dateForLesson = await _context.DateForLesson.FindAsync(id);
            _context.DateForLesson.Remove(dateForLesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateForLessonExists(int id)
        {
            return _context.DateForLesson.Any(e => e.DateForLessonId == id);
        }
    }
}
