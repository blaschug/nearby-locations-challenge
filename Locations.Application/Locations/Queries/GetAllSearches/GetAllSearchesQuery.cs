using Locations.Contracts.Locations;
using MediatR;

namespace Locations.Application.Locations.Commands.Queries
{
    public record GetAllSearchesQuery() 
        : IRequest<List<GetSearchResponse>>;
}