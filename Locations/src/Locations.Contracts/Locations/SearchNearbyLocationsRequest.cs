namespace Locations.Contracts.Locations
{
    public record SearchNearbyLocationsRequest(
        double Latitude,
        double Longitude,
        string Category);
}

