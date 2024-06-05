using System.Text.Json.Serialization;

namespace WeatherAppMobile.Models.OpenWeather;

[Serializable]
public record OpenWeatherDataCoordModel
{
    [JsonPropertyName("lat")]
    public required float Latitude { get; init; }

    [JsonPropertyName("lon")]
    public required float Longitude { get; init; }

}
