using Locations.Domain.Abstractions;
using Locations.Domain.LocationsSearches.ValueObjects;

namespace Locations.Domain.LocationsSearches.Entities;

public class LocationInfo : Entity
{
    public string LocationId { get; set; }
    public string Name { get; set; }
    public Coordinates Coordinates { get; set; }
}