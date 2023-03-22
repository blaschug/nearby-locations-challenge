using Locations.Contracts.Locations;
using MediatR;

namespace Locations.Application.Locations.Commands.SearchNearbyLocations
{
    public record SearchNearbyLocationsCommand(
        double Latitude,
        double Longitude,
        string Category) : IRequest<SearchNearbyLocationsResponse>;
}