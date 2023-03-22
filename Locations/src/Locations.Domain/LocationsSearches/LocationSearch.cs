using Locations.Domain.Abstractions;
using Locations.Domain.LocationsSearches.Entities;

namespace Locations.Domain.LocationsSearches;

public class LocationSearch : Entity
{
    public string ProviderName { get; set; }
    public LocationSearchRequest Request { get; set; }
    public LocationSearchResponse Response { get; set; }
    public DateTime Created { get; set; }
}