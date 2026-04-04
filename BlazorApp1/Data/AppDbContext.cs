using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    public class AppDbContext : DbContext  // Added from CoPilot Search about MySQL
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ShowElement> ShowElements => Set<ShowElement>(); // { get; set; }
    }
}
