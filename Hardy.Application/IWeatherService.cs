using Hardy.Common;
using Hardy.Domain.Weather;
using System.Threading.Tasks;

namespace Hardy.Application
{
    public interface IWeatherService
    {
        Task<Result<DomainWeather>> GetWeatherAsync();
    }
}