using System.Threading.Tasks;
using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;

namespace Hardy.Gateways.Redis
{
    public interface IWeatherCacheManager
    {
        Task<Result<CurrentWeatherResponse>> GetCurrentWeatherAsync();
        Task<bool> SetCurrentWeatherAsync(CurrentWeatherResponse currentWeatherResponse);
    }
}