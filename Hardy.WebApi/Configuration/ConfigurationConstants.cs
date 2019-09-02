namespace Hardy.WebApi.Configuration
{
    public class ConfigurationConstants
    {
        public static class OpenWeatherMap
        {
            public static string Prefix = "OpenWeatherMap";
            public static string ApiKey => AddPrefix("ApiKey");
            public static string BaseAddress => AddPrefix("BaseAddress");

            public static string Units => AddPrefix("Units");

            public static string CityId => AddPrefix("CityId");

            private static string AddPrefix(string key) => $"{Prefix}:{key}";
        }

        public static string RedisConnection = "RedisConnection";
    }
}
