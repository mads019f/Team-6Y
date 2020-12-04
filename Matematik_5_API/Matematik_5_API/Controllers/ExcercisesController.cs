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
    [Route("excercise")]
    [ApiController]
    public class ExcercisesController : ControllerBase
    {
        private readonly DomainDbContext _context;

        public ExcercisesController(DomainDbContext context)
        {
            _context = context;
        }

        // GET: api/Excercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Excercise>>> GetExcercises()
        {
            return await _context.Excercises.ToListAsync();
        }

        // GET: api/Excercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Excercise>> GetExcercise(int id)
        {
            var excercise = await _context.Excercises.FindAsync(id);

            if (excercise == null)
            {
                return NotFound();
            }

            return excercise;
        }

        // PUT: api/Excercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcercise(int id, Excercise excercise)
        {
            if (id != excercise.ID)
            {
                return BadRequest();
            }

            _context.Entry(excercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcerciseExists(id))
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

        // POST: api/Excercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Excercise>> PostExcercise(Excercise excercise)
        {
            _context.Excercises.Add(excercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExcercise", new { id = excercise.ID }, excercise);
        }

        // DELETE: api/Excercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcercise(int id)
        {
            var excercise = await _context.Excercises.FindAsync(id);
            if (excercise == null)
            {
                return NotFound();
            }

            _context.Excercises.Remove(excercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExcerciseExists(int id)
        {
            return _context.Excercises.Any(e => e.ID == id);
        }
    }
}
