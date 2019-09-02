using Hardy.Common.Responses.OpenWeatherMap;

namespace Hardy.Domain.Weather
{
    public class DomainWeatherAdapter
    {
        public static DomainWeather ToDomainWeather(CurrentWeatherResponse currentWeatherResponse)
        {
            var wind = new Wind(currentWeatherResponse.wind.speed, currentWeatherResponse.wind.deg);
            var precipitation = new Precipitation(currentWeatherResponse.weather[0].description);
            return new DomainWeather(currentWeatherResponse.main.humidity, currentWeatherResponse.main.temp, 
                currentWeatherResponse.name, wind, precipitation);
        }
    }
}
