using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Hardy.Gateways.OpenWeather
{
    public class OpenWeatherMapRequestBuilder
    {
        public string Resource;
        private Dictionary<string, string> QueryParams = new Dictionary<string, string>();

        public OpenWeatherMapRequestBuilder(string resource, string apiKey)
        {
            Resource = resource;
            QueryParams.Add(OpenWeatherMapConstants.QueryParamKeys.ApiKey, apiKey);
        }

        public OpenWeatherMapRequestBuilder AddParameter(string key, string value)
        {
            QueryParams.Add(key, value);
            return this;
        }

        public string ToQueryParameters(KeyValuePair<string, string> keyValuePair) =>
            $"{HttpUtility.UrlEncode(keyValuePair.Key)}={HttpUtility.UrlEncode(keyValuePair.Value)}";

        public string ToQueryString(IEnumerable<string> queryParams) => $"{Resource}?" + string.Join("&", queryParams);

        public string Build() => ToQueryString(QueryParams.Select(ToQueryParameters));
    }
}
