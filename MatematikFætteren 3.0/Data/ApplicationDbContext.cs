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
       
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<ExcerciseCategory> ExcerciseCategories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<PremiumExcercise> PremiumExcercises { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }







        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
