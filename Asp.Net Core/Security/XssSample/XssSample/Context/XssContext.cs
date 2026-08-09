using Microsoft.EntityFrameworkCore;
using XssSample.Models.Entities;

namespace XssSample.Context
{
    public class XssContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public XssContext(DbContextOptions options) : base(options)
        {
        }
    }
}
