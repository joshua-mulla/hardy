namespace Hardy.Common.Configurations
{
    public interface IOpenWeatherMapClientConfig
    {
        string ApiKey { get; set; }
        string BaseAddress { get; set; }
    }
}