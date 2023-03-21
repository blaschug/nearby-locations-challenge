using Locations.Infrastructure.Constants;

namespace Locations.Infrastructure.Exceptions
{
    public class InvalidLocationsProviderNameException : InfrastructureException
    {
        public InvalidLocationsProviderNameException() 
            : base(ProviderConstants.ExceptionMessages.InvalidProviderName)
        {
        }
    }
}
