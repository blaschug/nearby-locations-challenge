namespace Locations.Contracts.Providers
{
    public class GoogleRootResponse
    {
        public List<GoogleResults> Results { get; set; }
        public string Status { get; set; }
    }

    public class GoogleResults
    {
        public Geometry Geometry { get; set; }
        public string Name { get; set; }
        public string Place_Id { get; set; }
        public List<string> Types { get; set; }
    }

    public class Geometry
    {
        public Location Location { get; set; }
    }

    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}