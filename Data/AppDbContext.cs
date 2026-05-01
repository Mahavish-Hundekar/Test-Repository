<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Data
=======
﻿using GroceryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Data
>>>>>>> 0ef7ab7f4ef1003900307c2bd54c6c0e7e18ca62
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
<<<<<<< HEAD
=======
        public DbSet<Grocery> Groceries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   // ✅ IMPORTANT

            // Optional: Configure tables (clean structure)
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Grocery>().ToTable("Groceries");
        }
>>>>>>> 0ef7ab7f4ef1003900307c2bd54c6c0e7e18ca62
    }
}