using Locations.Contracts.Providers;
using Locations.Contracts.Providers.Locations;

namespace Locations.Application.Commons.Interfaces
{
    public interface ILocationsProvider
    {
        public Task<ProviderResult> SearchLocationsAsync(double latitude, double longitude, string category);
    }
}