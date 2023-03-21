using Locations.Application.Commons.Interfaces.Persistance;
using Locations.Contracts.Locations;
using MediatR;

namespace Locations.Application.Locations.Queries.GetAllSearches
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

            var searchResponses = locationSearches.ConvertAll<GetSearchResponse>(ls =>
            {
                return new GetSearchResponse(
                    ls.Id,
                    ls.ProviderName,
                    new LocationSearchRequest(
                        ls.Request.Id,
                        ls.Request.Coordinates.Latitude,
                        ls.Request.Coordinates.Longitude,
                        ls.Request.Category),
                    new LocationSearchResponse(
                        ls.Response.Id,
                        ls.Response.CategoryFilteredBy,
                        ls.Response.NearLocations.ConvertAll<LocationInfoResponse>(lir =>
                        {
                            return new LocationInfoResponse(
                                lir.Id,
                                lir.LocationId,
                                lir.Name,
                                lir.Coordinates.Latitude,
                                lir.Coordinates.Longitude);
                        })),
                    ls.Created
                );
            });

            return searchResponses;
        }
    }
}