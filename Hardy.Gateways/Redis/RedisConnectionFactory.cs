using StackExchange.Redis;
using System;

namespace Hardy.Gateways.Redis
{
    public class RedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> Connection;

        public RedisConnectionFactory(string connectionString)
        {
            var options = ConfigurationOptions.Parse(connectionString);

            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }

        public ConnectionMultiplexer GetConnection() => Connection.Value;
    }
}
