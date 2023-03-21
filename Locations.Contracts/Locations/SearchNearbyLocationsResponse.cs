namespace Locations.Contracts.Locations
{
    public record SearchNearbyLocationsResponse(
        double RequestedLatitude,
        double RequestedLongitude,
        string? CategoryFilteredBy,
        List<NearbyLocationInfoResponse> NearbyLocations);
    
    public record NearbyLocationInfoResponse(
        string LocationId,
        string Name,
        double Latitude,
        double Longitude);
}



