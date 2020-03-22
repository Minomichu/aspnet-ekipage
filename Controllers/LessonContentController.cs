using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ekipage.Data;
using ekipage.Models;
using Microsoft.AspNetCore.Authorization;

namespace ekipage.Controllers
{
    public class LessonContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonContentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LessonContent
        public async Task<IActionResult> Index()
        {
            return View(await _context.LessonContent.ToListAsync());
        }

        // GET: LessonContent/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonContent = await _context.LessonContent
                .FirstOrDefaultAsync(m => m.LessonContentId == id);
            if (lessonContent == null)
            {
                return NotFound();
            }

            return View(lessonContent);
        }

        // GET: LessonContent/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LessonContent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("LessonContentId,Lesson")] LessonContent lessonContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lessonContent);
        }

        // GET: LessonContent/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonContent = await _context.LessonContent.FindAsync(id);
            if (lessonContent == null)
            {
                return NotFound();
            }
            return View(lessonContent);
        }

        // POST: LessonContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("LessonContentId,Lesson")] LessonContent lessonContent)
        {
            if (id != lessonContent.LessonContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonContentExists(lessonContent.LessonContentId))
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
            return View(lessonContent);
        }

        // GET: LessonContent/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonContent = await _context.LessonContent
                .FirstOrDefaultAsync(m => m.LessonContentId == id);
            if (lessonContent == null)
            {
                return NotFound();
            }

            return View(lessonContent);
        }

        // POST: LessonContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessonContent = await _context.LessonContent.FindAsync(id);
            _context.LessonContent.Remove(lessonContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonContentExists(int id)
        {
            return _context.LessonContent.Any(e => e.LessonContentId == id);
        }
    }
}
