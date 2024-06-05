using System.Net.Http.Json;
using WeatherAppMobile.Models.CombinedWeather;
using WeatherAppMobile.Models.OpenWeather;
using WeatherAppMobile.Services.Errors;

namespace WeatherAppMobile.Services;
public sealed class WeatherDtmcPortfolioHTTPService
{
    private readonly HttpClient _client;
    private readonly Error? _isActive;
    private readonly string _combinedWeather = "api/v1/CombinedWeather/";
    private readonly string _combinedLatLong = "combinedlatlong?";
    private readonly string _combinedLocation = "combinedlocation?";

    public WeatherDtmcPortfolioHTTPService(HttpClient client)
    {
        _client = client;
    }

    public async Task<Result<CombinedWeatherDataModel>> GetWeatherData(
        string? latitude = null, string? longitude = null, string? location = null)
    {
        if (latitude is not null && longitude is not null)
        {
            var latLong = new LatLongEntity(latitude, longitude);

            return await GetWeatherDataByLatLong(latLong, CancellationToken.None);
        }


        if (location is not null)
            return await GetWeatherDataByLocation(location, CancellationToken.None);

        return new Result<CombinedWeatherDataModel>(WeatherPortfolioHTTPServiceErrors.ErrorMissingDataFromUser());
    }

    private async Task<Result<CombinedWeatherDataModel>> GetWeatherDataByLatLong(
        LatLongEntity latLong,
        CancellationToken cancellationToken = default)
    {
        if (_isActive != null)
            return new Result<CombinedWeatherDataModel>(_isActive);

        if (latLong.IsEmpty())
            return new Result<CombinedWeatherDataModel>(WeatherPortfolioHTTPServiceErrors.LatOrLongIsNull(latLong.ToString()));

        var url = $"{_combinedWeather}{_combinedLatLong}lat={latLong.Latitude}&lon={latLong.Longitude}";
        var response = await GetResultFromWeatherService<CombinedWeatherDataModel>(url, cancellationToken);

        return response;
    }

    private async Task<Result<CombinedWeatherDataModel>> GetWeatherDataByLocation(
        string location,
        CancellationToken cancellationToken = default)
    {
        if (_isActive != null)
            return new Result<CombinedWeatherDataModel>(_isActive);

        if (location is null)
            return new Result<CombinedWeatherDataModel>(WeatherPortfolioHTTPServiceErrors.LocationIsEmpty(location));

        var url = $"{_combinedWeather}{_combinedLocation}location={location}";
        var response = await GetResultFromWeatherService<CombinedWeatherDataModel>(url, cancellationToken);

        return response;
    }

    private async Task<Result<T>> GetResultFromWeatherService<T>(
        string url,
        CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response;

        if (_isActive != null)
            return new Result<T>(_isActive);

        try
        {
            response = await _client.GetAsync(url, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Result<T>(WeatherPortfolioHTTPServiceErrors.ErrorContactingWeatherService(ex.Message));
        }

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
            if (jsonResponse == null)
                return new Result<T>(WeatherPortfolioHTTPServiceErrors.ErrorResponseFromWeatherService("Response is null."));

            return jsonResponse;
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<OpenWeatherErrorModel>(cancellationToken);

            return new Result<T>(WeatherPortfolioHTTPServiceErrors.ErrorResponseFromWeatherService(string.Format("{0}:{1}", error?.Code, error?.Message)));
        }
    }
}
