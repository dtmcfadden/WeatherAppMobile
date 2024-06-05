namespace WeatherAppMobile.Models.CombinedWeather;

[Serializable]
public record CombinedWeatherCoordModel
{
    public required float Latitude { get; init; }
    public required float Longitude { get; init; }
}
