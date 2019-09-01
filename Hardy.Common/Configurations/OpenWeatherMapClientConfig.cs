using System;
using System.Collections.Generic;
using System.Text;

namespace Hardy.Common.Configurations
{
    public class OpenWeatherMapClientConfig : IOpenWeatherMapClientConfig
    {
        public string ApiKey { get; set; }
        public string BaseAddress { get; set; }
        public string Units { get; set; }
    }
}
