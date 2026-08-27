using AutoMapperSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperSample.Contexts
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
