using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;
using Hardy.Gateways.OpenWeather;
using System.Threading.Tasks;

namespace Hardy.Application
{
    public class WeatherService : IWeatherService
    {
        private readonly IOpenWeatherGateway openWeatherGateway;

        public WeatherService(IOpenWeatherGateway openWeatherGateway)
        {
            this.openWeatherGateway = openWeatherGateway;
        }

        public async Task<Result<CurrentWeatherResponse>> GetWeatherAsync()
        {
            return await openWeatherGateway.GetCurrentWeatherAsync();
        }
    }
}
