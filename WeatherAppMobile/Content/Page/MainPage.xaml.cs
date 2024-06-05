using System.Text.Json;
using WeatherAppMobile.Models.CombinedWeather;
using WeatherAppMobile.Services;
using WeatherAppMobile.ViewModel;

namespace WeatherAppMobile.Content.Page;

public partial class MainPage : ContentPage
{
    //private IConnectivity connectivity;
    private WeatherDtmcPortfolioHTTPService weatherService;

    public MainPage(MainViewModel viewModel,
        //IConnectivity connectivity,
        WeatherDtmcPortfolioHTTPService weatherService)
    {
        InitializeComponent();
        BindingContext = viewModel;

        //this.connectivity = connectivity;
        this.weatherService = weatherService;

        WeatherSource.SelectedIndex = 0;
        LocationType.SelectedIndex = 0;

        HanldeButtonClick();
    }

    void OnWeatherSourceSelectedIndexChanged(object sender, EventArgs e)
    {
        var selected = ((Picker)sender).SelectedItem;


    }

    void OnLocationTypeSelectedIndexChanged(object sender, EventArgs e)
    {
        var selected = ((Picker)sender).SelectedItem;

        switch (selected.ToString())
        {
            case "Latitude Longitude":
                LocationGrid.IsVisible = false;
                LatLongGrid.IsVisible = true;
                break;
            default:
                LocationGrid.IsVisible = true;
                LatLongGrid.IsVisible = false;
                break;
        }
    }

    void OnSubmitFormBtnClicked(object sender, EventArgs e)
    {
        HanldeButtonClick();
    }

    private async void HanldeButtonClick()
    {
        IsBusy = true;

        using var stream = await FileSystem.OpenAppPackageFileAsync("CombinedWeatherDataTest.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        var weatherData = JsonSerializer.Deserialize<CombinedWeatherDataModel>(contents);

        if (weatherData != null)
        {
            var navParameter = new Dictionary<string, object> {
            {
                "WeatherData", weatherData
            } };

            await Shell.Current.GoToAsync(nameof(DisplayWeatherResultsPage), true, navParameter);
        }

        //var locType = LocationType.SelectedItem.ToString();
        //if (locType is not null)
        //{
        //    var weatherData = locType switch
        //    {
        //        "Latitude Longitude" => await weatherService.GetWeatherData(
        //            latitude: LatitudeEntry.Text, longitude: LongitudeEntry.Text),
        //        _ => await weatherService.GetWeatherData(location: LocationEntry.Text)
        //    };

        //    if (weatherData is not null
        //        && weatherData.IsSuccess == true
        //        && weatherData.Value is not null)
        //    {
        //        var navParameter = new Dictionary<string, object> {
        //            {
        //                "WeatherData", weatherData.Value
        //            } };

        //        await Shell.Current.GoToAsync(nameof(DisplayWeatherResultsPage), true, navParameter);
        //    }
        //}
        IsBusy = false;
    }
}

