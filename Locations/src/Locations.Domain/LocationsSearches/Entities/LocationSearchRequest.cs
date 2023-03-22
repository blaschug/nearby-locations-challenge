using Locations.Domain.LocationsSearches.ValueObjects;

namespace Locations.Domain.LocationsSearches.Entities;

public class LocationSearchRequest
{
    public string Id { get; set; }
    public Coordinates Coordinates { get; set; }
    public string? Category { get; set; }
}