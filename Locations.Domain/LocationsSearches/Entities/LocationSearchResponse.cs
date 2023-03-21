namespace Locations.Domain.LocationsSearches.Entities;

public class LocationSearchResponse
{
    public string Id { get; set; }
    public string? CategoryFilteredBy { get; set; }
    public List<LocationInfo> NearLocations = new();
}