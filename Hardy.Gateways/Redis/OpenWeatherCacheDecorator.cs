using Hardy.Common;
using Hardy.Common.Responses.OpenWeatherMap;
using Hardy.Gateways.OpenWeather;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Hardy.Gateways.Redis
{
    public class OpenWeatherCacheDecorator : IOpenWeatherApiClient
    {
        private readonly IRedisDataAgent _redisDataAgent;
        private readonly OpenWeatherApiClient _openWeatherApiClient;

        public OpenWeatherCacheDecorator(IRedisDataAgent redisDataAgent, OpenWeatherApiClient openWeatherApiClient)
        {
            _redisDataAgent = redisDataAgent;
            _openWeatherApiClient = openWeatherApiClient;
        }

        public async Task<Result<CurrentWeatherResponse>> GetCurrentWeatherAsync()
        {
            var cachedCurrentWeather = await GetCurrentWeatherFromCache();
            if(cachedCurrentWeather.Succeeded && cachedCurrentWeather.Content != null)
            {
                return cachedCurrentWeather;
            }
            
            var currentWeather = await _openWeatherApiClient.GetCurrentWeatherAsync();
            await SetCurrentWeatherAsync(cachedCurrentWeather.Content);

            return currentWeather;
        }

        private const string CURRENT_WEATHER_KEY = "CurrentWeather";

        public async Task<Result<CurrentWeatherResponse>> GetCurrentWeatherFromCache()
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
            return await _redisDataAgent.SetStringValueAsync(CURRENT_WEATHER_KEY, JsonConvert.SerializeObject(currentWeatherResponse), TimeSpan.FromMinutes(30));
        }
    }
}
