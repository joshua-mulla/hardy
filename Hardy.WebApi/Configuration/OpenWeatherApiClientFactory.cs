using Hardy.Gateways.OpenWeather;
using Hardy.Gateways.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hardy.WebApi.Configuration
{
    public class OpenWeatherApiClientFactory
    {
        private readonly OpenWeatherApiClient _openWeatherApiClient;
        private readonly RedisConnectionFactory _redisConnectionFactory;

        public OpenWeatherApiClientFactory(OpenWeatherApiClient openWeatherApiClient, RedisConnectionFactory redisConnectionFactory)
        {
            _openWeatherApiClient = openWeatherApiClient;
            _redisConnectionFactory = redisConnectionFactory;
        }

        public IOpenWeatherApiClient Create() =>
            _openWeatherApiClient;

        public IOpenWeatherApiClient CreateWithCache() =>
            new OpenWeatherCacheDecorator(new RedisDataAgent(_redisConnectionFactory), _openWeatherApiClient);
        
    }
}
