using Locations.Domain.LocationsSearches.ValueObjects;

namespace Locations.Domain.LocationsSearches.Entities;

public class LocationInfo
{
    public string Id { get; set; }
    public string LocationId { get; set; }
    public string Name { get; set; }
    public Coordinates Coordinates { get; set; }
}