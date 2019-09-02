using System;
using System.Collections.Generic;
using System.Text;

namespace Hardy.Domain.Weather
{
    public class DomainWeather
    {
        public double Humidity { get; }
        public double Temperature { get; }
        public string CityKey { get; }
        public Wind Wind { get; }
        public Precipitation Precipitation { get; }

        public DomainWeather(double humidity, double temperature, string cityKey, Wind wind, Precipitation precipitation)
        {
            Humidity = humidity;
            Temperature = temperature;
            CityKey = cityKey;
            Wind = wind;
            Precipitation = precipitation;
        }
    }

    public class Wind
    {
        public double Speed { get; }
        private string[] _directions = new string[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
        public double DirectionDegrees { get; }
        public string Direction => _directions[(int)DirectionDegrees % 16];

        public Wind(double speed, double directionDegrees)
        {
            Speed = speed;
            DirectionDegrees = directionDegrees;
        }
    }

    public class Precipitation
    {
        public Precipitation(string description)
        {
            Description = description;
        }

        public string Description { get; }

        // TODO: icon
    }
}
