using GroceryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Grocery> Groceries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   // ✅ IMPORTANT

            // Optional: Configure tables (clean structure)
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Grocery>().ToTable("Groceries");
        }
    }
}