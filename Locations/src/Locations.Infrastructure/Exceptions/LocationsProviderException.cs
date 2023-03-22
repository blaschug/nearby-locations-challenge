using Locations.Infrastructure.Constants;

namespace Locations.Infrastructure.Exceptions
{
    public class LocationsProviderException : InfrastructureException
    {
        public LocationsProviderException() 
            : base(ProviderConstants.ExceptionMessages.UnavailableProvider)
        {
        }
    }
}