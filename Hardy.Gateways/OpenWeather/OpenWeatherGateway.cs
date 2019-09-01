using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;
using Hardy.Gateways.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hardy.Gateways.OpenWeather
{
    public class OpenWeatherGateway : IOpenWeatherGateway
    {
        private readonly IOpenWeatherApiClient _openWeatherApiClient;
        private readonly IWeatherCacheManager _weatherCacheManager;

        public OpenWeatherGateway(IOpenWeatherApiClient openWeatherApiClient, IWeatherCacheManager weatherCacheManager)
        {
            _openWeatherApiClient = openWeatherApiClient;
            _weatherCacheManager = weatherCacheManager;
        }

        public async Task<Result<CurrentWeatherResponse>> GetCurrentWeatherAsync()
        {
            var cachedWeather = await _weatherCacheManager.GetCurrentWeatherAsync();
            if (cachedWeather.Succeeded && cachedWeather.Content != null)
            {
                return cachedWeather;
            }

            var result = await _openWeatherApiClient.GetCurrentWeatherAsync();
            if (result.Succeeded)
            {
                await _weatherCacheManager.SetCurrentWeatherAsync(result.Content);
            }

            return result;
        }
    }
}
