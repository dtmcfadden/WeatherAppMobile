using WeatherAppMobile.Content.Page;

namespace WeatherAppMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DisplayWeatherResultsPage), typeof(DisplayWeatherResultsPage));
    }
}
