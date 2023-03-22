namespace Locations.Contracts.Locations
{
    public record GetSearchResponse(
        string Id,
        string ProviderName,
        LocationSearchRequest Request,
        LocationSearchResponse Response,
        DateTime Created);

    public record LocationSearchRequest(
        string Id,
        double Latitude,
        double Longitude,
        string? Category);

    public record LocationSearchResponse(
        string Id,
        string? CategoryFilteredBy,
        List<LocationInfoResponse> LocationsInfo);

    public record LocationInfoResponse(
        string Id,
        string LocationId,
        string Name,
        double Latitude,
        double Longitude);
}