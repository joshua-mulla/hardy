using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;
using System.Threading.Tasks;

namespace Hardy.Gateways.OpenWeather
{
    public interface IOpenWeatherApiClient
    {
        Task<Result<CurrentWeatherResponse>> GetCurrentWeatherAsync();
        Task<Result<ForecastResponse>> GetForecastAsync();
    }
}