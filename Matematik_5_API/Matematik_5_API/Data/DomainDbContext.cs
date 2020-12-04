using Matematik_5_API.Models.WebModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik_5_API.Data
{
    public class DomainDbContext : DbContext
    {
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<ExcerciseCategory> ExcerciseCategories { get; set; }
        public DomainDbContext ( DbContextOptions<DomainDbContext> options )
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
