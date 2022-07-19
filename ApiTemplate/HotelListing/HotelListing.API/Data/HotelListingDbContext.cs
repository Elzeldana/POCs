using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext: DbContext
    {
        public HotelListingDbContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"

                },
                new Country
                {
                    Id = 2,
                    Name = "Monaco",
                    ShortName = "MC"
                }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Sandals", Address = "Negri", CountryId = 1, Rating = 4.5 },
                new Hotel { Id = 2, Name = "Comfort", Address = "George Town", CountryId = 2, Rating = 4.3 }                
                );
        }
    }
}

// add-migration InitialMigration
// update database