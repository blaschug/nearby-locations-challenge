using Locations.Domain.Abstractions;

namespace Locations.Domain.LocationsSearches.Entities;

public class LocationSearchResponse : Entity
{
    public string? CategoryFilteredBy { get; set; }
    public List<LocationInfo> NearLocations = new();
}