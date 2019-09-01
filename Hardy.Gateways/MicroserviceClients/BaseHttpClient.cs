using Hardy.Common;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hardy.Gateways.MicroserviceClients
{
    public abstract class BaseHttpClient
    {
        protected readonly HttpClient _client;

        protected BaseHttpClient(HttpClient client)
        {
            _client = client;
        }

        protected BaseHttpClient(HttpClient client, string baseAddress)
        {
            _client = client;
            _client.BaseAddress = new Uri(baseAddress);
        }

        protected async Task<Result<T>> DeserializeAsync<T>(HttpResponseMessage response)
        {
            try
            {
                return new Result<T>(JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()));
            }
            catch (Exception ex)
            {
                return new Result<T>(ex.ToString());
            }
        }

    }
}
