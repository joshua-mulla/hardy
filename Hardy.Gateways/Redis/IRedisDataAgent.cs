using System.Threading.Tasks;

namespace Hardy.Gateways.Redis
{
    public interface IRedisDataAgent
    {
        Task<bool> DeleteStringValueAsync(string key);
        Task<string> GetStringValueAsync(string key);
        Task<bool> SetStringValueAsync(string key, string value);
    }
}