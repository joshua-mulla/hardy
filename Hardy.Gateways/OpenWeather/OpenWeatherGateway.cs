using Hardy.Common;
using Hardy.Domain.Weather;
using System.Threading.Tasks;

namespace Hardy.Gateways.OpenWeather
{
    public class OpenWeatherGateway : IOpenWeatherGateway
    {
        private readonly IOpenWeatherApiClient _openWeatherApiClient;

        public OpenWeatherGateway(IOpenWeatherApiClient openWeatherApiClient)
        {
            _openWeatherApiClient = openWeatherApiClient;
        }

        public async Task<Result<DomainWeather>> GetCurrentWeatherAsync()
        {
            var getDomainWeather = await _openWeatherApiClient.GetCurrentWeatherAsync();
            if (getDomainWeather.Failed)
            {
                return new Result<DomainWeather>(getDomainWeather.ErrorMessage);
            }

            return new Result<DomainWeather>(DomainWeatherAdapter.ToDomainWeather(getDomainWeather.Content));
        }
    }
}
