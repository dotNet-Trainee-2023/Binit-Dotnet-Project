using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions dBContextOptions) : base(dBContextOptions)
        {
        }

        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var placeList = new List<Place>()
             {
            new Place()
            {
                Id = Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "Kathmandu Durbar Square",
                Location = "KTM"
            }
            };

            modelBuilder.Entity<Place>().HasData(placeList);

        }

    }
}

