using System.Text.Json.Serialization;

namespace WeatherAppMobile.Models.WeatherAPI;

public record WeatherAPIErrorModel
{
    [JsonPropertyName("error")]
    public required WeatherAPIInnerErrorModel Error { get; init; }

    public override string ToString()
    {
        return Error.Code + ": " + Error.Message;
    }
}