using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Hardy.Gateways.Redis
{
    public class RedisDataAgent : IRedisDataAgent
    {
        private static IDatabase _database;
        private readonly RedisConnectionFactory _redisConnectionFactory;
        public RedisDataAgent(RedisConnectionFactory redisConnectionFactory)
        {
            _redisConnectionFactory = redisConnectionFactory;
            var connection = _redisConnectionFactory.GetConnection();

            _database = connection.GetDatabase();
        }

        public async Task<string> GetStringValueAsync(string key)
        {
            return await _database.StringGetAsync(key);
        }

        public Task<bool> SetStringValueAsync(string key, string value, TimeSpan expiration)
        {
            return _database.StringSetAsync(key, value, expiration);
        }

        public Task<bool> DeleteStringValueAsync(string key)
        {
            return _database.KeyDeleteAsync(key);
        }
    }
}