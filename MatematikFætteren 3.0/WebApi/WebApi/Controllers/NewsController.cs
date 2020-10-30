using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly DomainDbContext _context;
        public NewsController (DomainDbContext context )
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsFromId (int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
               return NotFound();
            }
            return Ok(news);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews ( )
        {
            return Ok(await _context.News.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<News>> PostNews ([FromBody] News news )
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsFromId", new { id = news.NewsId }, news);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews([FromRoute] int id, [FromBody] News news )
        {
            if (id != news.NewsId)
            {
               return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.News.Find(id) == null)
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNewsFromId (int id )
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return news;
        }
       
    }
}