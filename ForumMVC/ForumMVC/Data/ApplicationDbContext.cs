using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ForumMVC.Models;

namespace ForumMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
            : base(options)
        {
            Database.Migrate();
        }
        public DbSet<ForumMVC.Models.Category> Category { get; set; }
        public DbSet<ForumMVC.Models.Post> Post { get; set; }
    }
}
