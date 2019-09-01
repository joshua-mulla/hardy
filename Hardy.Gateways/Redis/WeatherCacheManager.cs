using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hardy.Gateways.Redis
{
    public class WeatherCacheManager : IWeatherCacheManager
    {
        private readonly IRedisDataAgent _redisDataAgent;

        public WeatherCacheManager(IRedisDataAgent redisDataAgent)
        {
            _redisDataAgent = redisDataAgent;
        }

        private const string CURRENT_WEATHER_KEY = "CurrentWeather";
        public async Task<Result<CurrentWeatherResponse>> GetCurrentWeatherAsync()
        {
            try
            {
                var currentWeatherStr = await _redisDataAgent.GetStringValueAsync(CURRENT_WEATHER_KEY);
                if (string.IsNullOrEmpty(currentWeatherStr))
                {
                    return new Result<CurrentWeatherResponse>(null as CurrentWeatherResponse);
                }

                return new Result<CurrentWeatherResponse>(JsonConvert.DeserializeObject<CurrentWeatherResponse>(currentWeatherStr));
            }
            catch (Exception ex)
            {
                return new Result<CurrentWeatherResponse>($"Exception occurred while retrieving key {CURRENT_WEATHER_KEY} from redis: {ex}");
            }

        }

        public async Task<bool> SetCurrentWeatherAsync(CurrentWeatherResponse currentWeatherResponse)
        {
            return await _redisDataAgent.SetStringValueAsync(CURRENT_WEATHER_KEY, JsonConvert.SerializeObject(currentWeatherResponse));
        }
    }
}
