using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiftShop.Data;
using GiftShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace GiftShop.Controllers
{
    public class GiftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gifts.ToListAsync());
        }

        // GET: Gifts, overloaded metode til Index
        [Route("Index/from/{dd}/{mm}/{yyyy}/to/{dd2}/{mm2}/{yyyy2}")]
        public async Task<IActionResult> Index(int dd, int mm, int yyyy, int dd2, int mm2, int yyyy2)
        {
            DateTime date1 = new DateTime(yyyy,mm,dd);
            DateTime date2 = new DateTime(yyyy2, mm2, dd2);

            return View(await _context.Gifts.Where(x=> x.CreationDate>=date1 && x.CreationDate<=date2).ToListAsync());
        }

        public async Task<IActionResult> GirlGifts()
        {
            return View(await _context.Gifts.Where(g => g.GirlGift==true).ToListAsync());
        }


        // GET: Gifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await _context.Gifts
                .FirstOrDefaultAsync(m => m.GiftID == id);
            if (gift == null)
            {
                return NotFound();
            }

            return View(gift);
        }

        // GET: Gifts/Create
        [Authorize] // [Authorize(Role=Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        // Bind beskytter i mod overposting
        public async Task<IActionResult> Create([Bind("GiftID,Title,Description,BoyGift,GirlGift")] Gift gift)
        {
            if (ModelState.IsValid)
            {
                gift.CreationDate = DateTime.Now; // sætter creationdate automatisk
                _context.Add(gift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gift);
        }

        // GET: Gifts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await _context.Gifts.FindAsync(id);
            if (gift == null)
            {
                return NotFound();
            }
            return View(gift);
        }

        // POST: Gifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("GiftID,Title,Description,CreationDate,BoyGift,GirlGift")] Gift gift)
        {
            if (id != gift.GiftID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftExists(gift.GiftID))
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
            return View(gift);
        }

        // GET: Gifts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await _context.Gifts
                .FirstOrDefaultAsync(m => m.GiftID == id);
            if (gift == null)
            {
                return NotFound();
            }

            return View(gift);
        }

        // POST: Gifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gift = await _context.Gifts.FindAsync(id);
            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftExists(int id)
        {
            return _context.Gifts.Any(e => e.GiftID == id);
        }
    }
}
