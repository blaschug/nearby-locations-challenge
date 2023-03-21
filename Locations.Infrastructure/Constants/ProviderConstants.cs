namespace Locations.Infrastructure.Constants
{
    public class ProviderConstants
    {
        public static partial class Google
        {
            public const string NearbyLocationPath = "maps/api/place/nearbysearch/json";
            public const string ProviderName = "GOOGLE";
        }

        public static partial class ExceptionMessages
        {
            public const string UnavailableProvider = "External provider is not available. Try again in a few minutes.";
        }
    }
}