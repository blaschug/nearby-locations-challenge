using Locations.Domain.LocationsSearches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locations.Infrastructure.Configurations.Persistance
{
    public class LocationSearchConfigurations
        : IEntityTypeConfiguration<LocationSearch>
    {
        public void Configure(EntityTypeBuilder<LocationSearch> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}