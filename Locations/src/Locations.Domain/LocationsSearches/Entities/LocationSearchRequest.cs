using Locations.Domain.Abstractions;
using Locations.Domain.LocationsSearches.ValueObjects;

namespace Locations.Domain.LocationsSearches.Entities;

public class LocationSearchRequest : Entity
{
    public Coordinates Coordinates { get; set; }
    public string? Category { get; set; }
}