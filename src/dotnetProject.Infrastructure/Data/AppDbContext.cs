using Microsoft.EntityFrameworkCore;
using dotnetProject.Domain.Entities;

namespace dotnetProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;
    }
}

