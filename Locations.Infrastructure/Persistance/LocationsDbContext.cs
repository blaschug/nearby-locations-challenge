using Locations.Domain.LocationsSearches;
using Microsoft.EntityFrameworkCore;

namespace Locations.Infrastructure.Persistance
{
    public class LocationsDbContext : DbContext
    {
        public LocationsDbContext(DbContextOptions<LocationsDbContext> options)
            : base(options)
        {

        }

        public DbSet<LocationSearch> LocationSearches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationsDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
