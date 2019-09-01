using System.Threading.Tasks;
using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;

namespace Hardy.Gateways.OpenWeather
{
    public interface IOpenWeatherGateway
    {
        Task<Result<CurrentWeatherResponse>> GetCurrentWeatherAsync();
    }
}