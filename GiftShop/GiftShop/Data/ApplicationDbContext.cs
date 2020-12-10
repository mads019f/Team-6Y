using System;
using System.Collections.Generic;
using System.Text;
using GiftShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Gift> Gifts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
