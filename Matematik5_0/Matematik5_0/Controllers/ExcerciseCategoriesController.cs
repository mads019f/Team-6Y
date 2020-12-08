using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matematik5_0.Data;
using Matematik5_0.Models.WebModel;
using Matematik5_0.Models;

namespace Matematik5_0.Controllers
{
    public class ExcerciseCategoriesController : Controller
    {
        private readonly Service _service;
        private readonly UserDbContext _context;


        public ExcerciseCategoriesController(Service service, UserDbContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: ExcerciseCategories
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetExcerciseCategoriesAsync();
            return View(categories);
        }

        // GET: ExcerciseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excerciseCategory = await _context.ExcerciseCategory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (excerciseCategory == null)
            {
                return NotFound();
            }

            return View(excerciseCategory);
        }

        // GET: ExcerciseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExcerciseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title")] ExcerciseCategory excerciseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excerciseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excerciseCategory);
        }

        // GET: ExcerciseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excerciseCategory = await _context.ExcerciseCategory.FindAsync(id);
            if (excerciseCategory == null)
            {
                return NotFound();
            }
            return View(excerciseCategory);
        }

        // POST: ExcerciseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title")] ExcerciseCategory excerciseCategory)
        {
            if (id != excerciseCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excerciseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcerciseCategoryExists(excerciseCategory.ID))
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
            return View(excerciseCategory);
        }

        // GET: ExcerciseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excerciseCategory = await _context.ExcerciseCategory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (excerciseCategory == null)
            {
                return NotFound();
            }

            return View(excerciseCategory);
        }

        // POST: ExcerciseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excerciseCategory = await _context.ExcerciseCategory.FindAsync(id);
            _context.ExcerciseCategory.Remove(excerciseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcerciseCategoryExists(int id)
        {
            return _context.ExcerciseCategory.Any(e => e.ID == id);
        }
    }
}
