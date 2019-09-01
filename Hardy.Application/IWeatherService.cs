using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;
using System.Threading.Tasks;

namespace Hardy.Application
{
    public interface IWeatherService
    {
        Task<Result<CurrentWeatherResponse>> GetWeatherAsync();
    }
}