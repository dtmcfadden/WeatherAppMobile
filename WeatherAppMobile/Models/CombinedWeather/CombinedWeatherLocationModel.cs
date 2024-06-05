namespace WeatherAppMobile.Models.CombinedWeather;

[Serializable]
public record CombinedWeatherLocationModel
{
    public string? Name { get; init; }
    public string? Country { get; init; }
    public required int LocalTime { get; init; }
}
