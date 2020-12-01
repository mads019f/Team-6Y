using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ForumMVCV4.Models;

namespace ForumMVCV4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
            : base(options)
        {
        }
        public DbSet<ForumMVCV4.Models.Comment> Comment { get; set; }
    }
}
