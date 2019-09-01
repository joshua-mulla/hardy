using System;
using System.Net.Http;
using Hardy.Application;
using Hardy.Common.Configurations;
using Hardy.Gateways.OpenWeather;
using Hardy.Gateways.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Hardy.WebApi.Configuration
{
    public class IoCConfig
    {
        public static void RegisterDependencyChain(IServiceCollection services, IConfiguration configuration)
        {
            var breaker = Policy
              .Handle<HttpRequestException>()
              .CircuitBreaker(
                exceptionsAllowedBeforeBreaking: 2,
                durationOfBreak: TimeSpan.FromMinutes(1)
            );

            
            services.AddSingleton<IOpenWeatherMapClientConfig>(new OpenWeatherMapClientConfig
            {
                ApiKey = configuration[ConfigurationConstants.OpenWeatherMap.ApiKey],
                BaseAddress = configuration[ConfigurationConstants.OpenWeatherMap.BaseAddress],
                Units = configuration[ConfigurationConstants.OpenWeatherMap.Units]
            });

            services.AddHttpClient<IOpenWeatherApiClient, OpenWeatherApiClient>();
            services.AddSingleton(new RedisConnectionFactory(configuration[ConfigurationConstants.RedisConnection]));
            services.AddSingleton<IRedisDataAgent, RedisDataAgent>();
            services.AddSingleton<IWeatherCacheManager, WeatherCacheManager>();
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IOpenWeatherGateway, OpenWeatherGateway>();
        }
    }
}
