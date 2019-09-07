using Hardy.Common.Responses.OpenWeatherMap;

namespace Hardy.Domain.Weather
{
    public class DomainWeatherAdapter
    {
        public static DomainWeather ToDomainWeather(CurrentWeatherResponse currentWeatherResponse)
        {
            var wind = new Wind(currentWeatherResponse.Wind.Speed, currentWeatherResponse.Wind.Deg);
            var precipitation = new Precipitation(currentWeatherResponse.Weather[0].Description);
            return new DomainWeather(currentWeatherResponse.Main.Humidity, currentWeatherResponse.Main.Temp, 
                currentWeatherResponse.Name, wind, precipitation);
        }
    }
}
