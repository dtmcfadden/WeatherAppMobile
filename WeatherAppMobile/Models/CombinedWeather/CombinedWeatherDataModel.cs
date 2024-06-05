namespace WeatherAppMobile.Models.CombinedWeather;

[Serializable]
public record CombinedWeatherDataModel
{
    public required string ApiSource { get; set; }
    public required CombinedWeatherTemperatureModel CombinedWeatherTemperatureModel { get; set; }
    public required CombinedWeatherCoordModel CombinedWeatherCoordModel { get; set; }
    public required CombinedWeatherConditionModel CombinedWeatherConditionModel { get; set; }
    public required CombinedWeatherLocationModel CombinedWeatherLocationModel { get; set; }
}
