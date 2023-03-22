using Locations.Domain.LocationsSearches.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locations.Infrastructure.Configurations.Persistance
{
    public class LocationInfoConfigurations
        : IEntityTypeConfiguration<LocationInfo>
    {
        public void Configure(EntityTypeBuilder<LocationInfo> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(p => p.Coordinates);
        }
    }
}