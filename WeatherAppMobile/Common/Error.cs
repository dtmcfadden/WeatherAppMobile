namespace WeatherAppMobile.Common;
public sealed record Error(
    string Code,
    string? ClientMessage = null,
    string? LogMessage = null);
