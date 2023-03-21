using Locations.Domain.LocationsSearches.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locations.Infrastructure.Configurations.Persistance
{
    public class LocationSearchResponseConfigurations
        : IEntityTypeConfiguration<LocationSearchResponse>
    {
        public void Configure(EntityTypeBuilder<LocationSearchResponse> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}