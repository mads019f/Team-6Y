using GiftShop.Data;
using GiftShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.ViewComponents
{
    public class InStockViewComponent
    {
        private readonly ApplicationDbContext _context;

        public InStockViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public string Invoke()
        {
            int stockAmount = _context.Gifts.Count();
            return $"Total amount of gifts in stock: {stockAmount}";
        }
    }
}
