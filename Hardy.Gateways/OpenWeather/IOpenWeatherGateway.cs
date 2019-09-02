using System.Threading.Tasks;
using Hardy.Common;
using Hardy.Domain.Weather;

namespace Hardy.Gateways.OpenWeather
{
    public interface IOpenWeatherGateway
    {
        Task<Result<DomainWeather>> GetCurrentWeatherAsync();
    }
}