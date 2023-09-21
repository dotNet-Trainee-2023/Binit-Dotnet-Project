using Microsoft.EntityFrameworkCore;
using MVC_App.Models;

namespace MVC_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
