using Hardy.Common;
using Hardy.Domain.Weather;
using Hardy.Gateways.OpenWeather;
using System.Threading.Tasks;

namespace Hardy.Application
{
    public class WeatherService : IWeatherService
    {
        private readonly IOpenWeatherGateway _openWeatherGateway;

        public WeatherService(IOpenWeatherGateway openWeatherGateway)
        {
            _openWeatherGateway = openWeatherGateway;
        }

        public async Task<Result<DomainWeather>> GetWeatherAsync()
        {
            return await _openWeatherGateway.GetCurrentWeatherAsync();
        }
    }
}