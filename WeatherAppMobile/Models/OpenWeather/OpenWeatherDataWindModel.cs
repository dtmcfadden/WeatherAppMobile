using System.Text.Json.Serialization;

namespace WeatherAppMobile.Models.OpenWeather;

[Serializable]
public record OpenWeatherDataWindModel
{
    [JsonPropertyName("speed")]
    public required float Speed { get; init; }

    [JsonPropertyName("deg")]
    public required int Degrees { get; init; }

    [JsonPropertyName("gust")]
    public float? Gust { get; init; }
}
