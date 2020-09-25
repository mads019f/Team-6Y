using System;
using System.Collections.Generic;
using System.Text;
using Matematik.Models;
using Matematik.Models.Forum;
using MatematikFætteren_3._0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MatematikFætteren_3._0.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Forum> forum { get; set; } 
        public DbSet<Comment> comment { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
