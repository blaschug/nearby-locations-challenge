namespace Locations.Contracts.Providers
{
    public class ProviderResult
    {
        public string ProviderName { get; set; }
        public List<LocationResultInfo> NearbyLocationsFound { get; set; }
    }

    public class LocationResultInfo
    {
        public string LocationId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> Categories { get; set; }
    }
}