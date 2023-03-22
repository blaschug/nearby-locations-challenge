using System.Globalization;
using Locations.Application.Commons.Interfaces;
using Locations.Contracts.Providers;
using Locations.Contracts.Providers.Locations;
using Locations.Infrastructure.Constants;
using Locations.Infrastructure.Exceptions;
using RestSharp;

namespace Locations.Infrastructure.Providers.Locations
{
    public class GoogleLocationsProvider : ILocationsProvider
    {
        private readonly RestClient _restClient;

        public GoogleLocationsProvider(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ProviderResult> SearchLocationsAsync(double latitude, double longitude, string category)
        {
            var parsedLatitude = latitude.ToString(CultureInfo.InvariantCulture);
            var parsedLongitude = longitude.ToString(CultureInfo.InvariantCulture);
            var restRequest = NearbyLocationsGetRequest(parsedLatitude, parsedLongitude, category);
            GoogleRootResponse googleResponse;

            try
            {
                var executionResult = await _restClient.ExecuteAsync<GoogleRootResponse>(restRequest);

                googleResponse = executionResult.Data;
            }
            catch (Exception ex)
            {
                throw new LocationsProviderException();
            }

            var googleResults = googleResponse.Results.ConvertAll<LocationResultInfo>(x => 
                new LocationResultInfo
                {
                    LocationId = x.Place_Id,
                    Latitude = x.Geometry.Location.Lat,
                    Longitude = x.Geometry.Location.Lng,
                    Name = x.Name,
                    Categories = x.Types,
                });

            return new ProviderResult
            {
                ProviderName = ProviderConstants.Google.ProviderName,
                NearbyLocationsFound = googleResults,
            };
        }
        
        private static RestRequest NearbyLocationsGetRequest(string latitude, string longitude, string category)
        {
            var restRequest = new RestRequest(ProviderConstants.Google.NearbyLocationPath, Method.Get);
            restRequest.AddParameter("location", $"{latitude},{longitude}");
            restRequest.AddParameter("type", category);

            return restRequest;
        }
    }
}