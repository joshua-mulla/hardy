using Hardy.Common;
using Hardy.Common.Configurations;
using Hardy.Common.Responses.OpenWeatherMap;
using Hardy.Gateways.MicroserviceClients;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hardy.Gateways.OpenWeather
{
    public class OpenWeatherApiClient : BaseHttpClient, IOpenWeatherApiClient
    {
        private readonly IOpenWeatherMapClientConfig _config;

        public OpenWeatherApiClient(HttpClient client, IOpenWeatherMapClientConfig config) : base(client, config.BaseAddress)
        {
            _config = config;
        }

        public async Task<Result<CurrentWeatherResponse>> GetCurrentWeatherAsync()
        {
            var request = new OpenWeatherMapRequestBuilder(OpenWeatherMapConstants.ResourceKeys.Weather, _config.ApiKey)
                .AddParameter(OpenWeatherMapConstants.QueryParamKeys.CityId, _config.CityId)
                .AddParameter(OpenWeatherMapConstants.QueryParamKeys.Units, _config.Units)
                .Build();
            var rawResponse = await _client.GetAsync(request);
            if (rawResponse.IsSuccessStatusCode)
            {
                return await DeserializeAsync<CurrentWeatherResponse>(rawResponse);
            }

            return new Result<CurrentWeatherResponse>($"Failed to retrieve current weather from Open Weather API. Status code: {rawResponse.StatusCode}");
        }
    }
}
