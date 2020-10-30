using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApi.Data
{
    public class DomainDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DomainDbContext ( DbContextOptions<DomainDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
