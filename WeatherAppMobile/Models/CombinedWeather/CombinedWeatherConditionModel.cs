namespace WeatherAppMobile.Models.CombinedWeather;

[Serializable]
public record CombinedWeatherConditionModel
{
    public required string Description { get; init; }
    public required string Icon { get; init; }
    public required float Visibility { get; init; }
    public required float? WindSpeed { get; init; }
    public required int? WindDegree { get; init; }
    public required float? WindGust { get; init; }
    public required float? PrecipitationMm { get; init; }
    public required int? Clouds { get; init; }
}
