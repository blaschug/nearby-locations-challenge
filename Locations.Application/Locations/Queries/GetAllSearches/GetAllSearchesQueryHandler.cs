using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Contracts.Locations;
using MediatR;

namespace Locations.Application.Locations.Commands.Queries
{
    public class GetAllSearchesQueryHandler
        : IRequestHandler<GetAllSearchesQuery, List<GetSearchResponse>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetAllSearchesQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<GetSearchResponse>> Handle(GetAllSearchesQuery request, CancellationToken cancellationToken)
        {
            var locationSearches = await _locationRepository.GetAll();

            var searcesResponse = locationSearches.ConvertAll<GetSearchResponse>(p =>
            {
                return new GetSearchResponse(
                    p.Id,
                    p.ProviderName,
                    new LocationSearchRequest(
                        p.Request.Id,
                        p.Request.Coordinates.Latitude,
                        p.Request.Coordinates.Longitude,
                        p.Request.Category),
                    new LocationSearchResponse(
                        p.Response.Id,
                        p.Response.CategoryFilteredBy,
                        p.Response.NearLocations.ConvertAll<LocationInfoResponse>(q =>
                        {
                            return new LocationInfoResponse(
                                q.Id,
                                q.LocationId,
                                q.Name,
                                q.Coordinates.Latitude,
                                q.Coordinates.Longitude);
                        })),
                    p.Created
                );
            });

            return searcesResponse;
        }
    }
}