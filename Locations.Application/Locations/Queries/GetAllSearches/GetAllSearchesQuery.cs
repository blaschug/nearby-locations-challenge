using Locations.Contracts.Locations;
using MediatR;

namespace Locations.Application.Locations.Queries.GetAllSearches
{
    public record GetAllSearchesQuery() 
        : IRequest<List<GetSearchResponse>>;
}