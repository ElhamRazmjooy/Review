using BackgroundServiceSample.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundServiceSample.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
