using System.Text.Json;

namespace WeatherAppMobile.Options;
public static class DefaultGlobalOptions
{
    public static JsonSerializerOptions DefaultSerialize = new()
    {
        WriteIndented = true,
    };

}
