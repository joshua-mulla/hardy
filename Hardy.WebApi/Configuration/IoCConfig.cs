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
                ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
                BaseAddress = configuration[ConfigurationConstants.OpenWeatherMap.BaseAddress],
                Units = configuration[ConfigurationConstants.OpenWeatherMap.Units],
                CityId = configuration[ConfigurationConstants.OpenWeatherMap.CityId]
            });

            services.AddHttpClient<OpenWeatherApiClient>();
            services.AddSingleton<OpenWeatherApiClientFactory>();
            services.AddSingleton<IOpenWeatherApiClient>(sp => sp.GetService<OpenWeatherApiClientFactory>().Create());
            services.AddSingleton(new RedisConnectionFactory(configuration[ConfigurationConstants.RedisConnection]));
            
            //services.AddSingleton<IOpenWeatherApiClient>(sp => new OpenWeatherCacheDecorator(sp.GetService<IRedisDataAgent>(), sp.GetService<OpenWeatherApiClient>()));
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IOpenWeatherGateway, OpenWeatherGateway>();
        }
    }
}
