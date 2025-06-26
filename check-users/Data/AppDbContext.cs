using check_users.Models;
using Microsoft.EntityFrameworkCore;

namespace check_users.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<PunchClock> clocks { get; set; }
        public DbSet<GeoLocation> geoLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PunchClock>(entity =>
            {
                entity.OwnsOne(e => e.CheckInlocation);
                entity.OwnsOne(e => e.CheckOutlocation);
            });

        }

    }
}
