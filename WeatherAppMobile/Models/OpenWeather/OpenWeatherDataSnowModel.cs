using System.Text.Json.Serialization;

namespace WeatherAppMobile.Models.OpenWeather;

[Serializable]
public record OpenWeatherDataSnowModel
{
    [JsonPropertyName("1h")]
    public float? OneHourVolume { get; init; }

    [JsonPropertyName("3h")]
    public float? ThreeHourVolume { get; init; }
}
