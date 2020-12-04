using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Matematik_5_API.Data;
using Matematik_5_API.Models.WebModel;

namespace Matematik_5_API.Controllers
{
    [Route("excercisecategory")]
    [ApiController]
    public class ExcerciseCategoriesController : ControllerBase
    {
        private readonly DomainDbContext _context;

        public ExcerciseCategoriesController(DomainDbContext context)
        {
            _context = context;
        }

        // GET: api/ExcerciseCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExcerciseCategory>>> GetExcerciseCategories()
        {
            return await _context.ExcerciseCategories
                .Include(e => e.Excercises)
                .ToListAsync();
        }

        // GET: api/ExcerciseCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExcerciseCategory>> GetExcerciseCategory(int id)
        {
            var excerciseCategory = await _context.ExcerciseCategories
                .Include(e => e.Excercises)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (excerciseCategory == null)
            {
                return NotFound();
            }

            return excerciseCategory;
        }

        // PUT: api/ExcerciseCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcerciseCategory(int id, ExcerciseCategory excerciseCategory)
        {
            if (id != excerciseCategory.ID)
            {
                return BadRequest();
            }

            _context.Entry(excerciseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcerciseCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ExcerciseCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExcerciseCategory>> PostExcerciseCategory(ExcerciseCategory excerciseCategory)
        {
            _context.ExcerciseCategories.Add(excerciseCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExcerciseCategory", new { id = excerciseCategory.ID }, excerciseCategory);
        }

        // DELETE: api/ExcerciseCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcerciseCategory(int id)
        {
            var excerciseCategory = await _context.ExcerciseCategories.FindAsync(id);
            if (excerciseCategory == null)
            {
                return NotFound();
            }

            _context.ExcerciseCategories.Remove(excerciseCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExcerciseCategoryExists(int id)
        {
            return _context.ExcerciseCategories.Any(e => e.ID == id);
        }
    }
}
