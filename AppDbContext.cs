using clothStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace clothStore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        // Add other DbSet properties for your models as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, indexes, etc. here
            // This method is optional, use it if you need to customize the model building process
        }
    }
}

