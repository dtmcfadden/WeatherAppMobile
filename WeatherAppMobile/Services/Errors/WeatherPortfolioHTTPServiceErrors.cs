namespace WeatherAppMobile.Services.Errors;
public static class WeatherPortfolioHTTPServiceErrors
{
    public static Error LocationIsEmpty(string? LogMessage = null) =>
        new("WeatherPortfolioHTTPService.LocationIsEmpty",
            "Location is empty",
            LogMessage);
    public static Error LatOrLongIsNull(string? LogMessage = null) =>
        new("WeatherPortfolioHTTPService.LatOrLongIsNull",
            "Latitude or Longitude is null.",
            LogMessage);
    public static Error LatLongIsEmpty(string? LogMessage = null) =>
        new("WeatherPortfolioHTTPService.LatLongIsEmpty",
            "LatLong is empty",
            LogMessage);
    public static Error ErrorContactingWeatherService(string? LogMessage = null) =>
        new("WeatherPortfolioHTTPService.ErrorContactingWeatherService",
            "Error contacting Weather Service",
            LogMessage);
    public static Error ErrorResponseFromWeatherService(string? LogMessage = null) =>
        new("WeatherPortfolioHTTPService.ErrorResponseFromOpenWeather",
            "Error response from Weather Service.",
            LogMessage);
    public static Error ErrorMissingDataFromUser(string? LogMessage = null) =>
        new("WeatherPortfolioHTTPService.ErrorMissingDataFromUser",
            "Missing Data from user",
            LogMessage);
}
