using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICRUD.Data;
using APICRUD.Models;
using APICRUD.Middleware;

namespace APICRUD.Controllers
{
    [ApiVersion("1.0")]
    [Route("Product")]
    [Produces("application/json", "application/xml")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
            
            
        }

        // GET: Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                
                return NotFound();
            }

            return product;
        }

        // PUT: Product/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute]int id, byte[] rowVersion)
        {
            var productToUpdate = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);


            if (productToUpdate == null)
            {

                return NotFound();
            }

            // Uden Optimistic Lock
            // _context.Entry(productToUpdate).State = EntityState.Modified;
            _context.Entry(productToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Product>(
                productToUpdate, "", p => p.Price, p => p.Name))

            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.Product.Find(id) == null)
                    {
                        return NotFound();
                    }
                    
                        //throw;
                    Conflict();
                }
            }
            return NoContent();
        }

        // POST: api/Product
        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody]Product product)
        {
            var httpRequestDateFeature = HttpContext.Features.Get<IHttpRequestDateFeature>();
            if (httpRequestDateFeature != null)
            {
                var requestDate = httpRequestDateFeature.RequestDate;
                product.DatetimeUS = requestDate;   

            }
            
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
           
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
