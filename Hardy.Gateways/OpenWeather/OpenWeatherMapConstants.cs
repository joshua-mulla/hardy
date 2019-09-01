using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hardy.Gateways.OpenWeather
{
    public class OpenWeatherMapConstants
    {
        public static class QueryParamKeys
        {
            public const string CityId = "id";

            public const string ApiKey = "APPID";
            public const string Units = "units";
        }

        public static class ResourceKeys
        {
            public const string Weather = "weather";
        }
    }
}
