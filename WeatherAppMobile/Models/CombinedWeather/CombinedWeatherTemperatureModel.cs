namespace WeatherAppMobile.Models.CombinedWeather;

[Serializable]
public record CombinedWeatherTemperatureModel
{
    public required float Kelvin { get; init; }
    public required float FeelsLikeKelvin { get; init; }
    public required float PressureMillibar { get; init; }
    public required int Humidity { get; init; }
}
