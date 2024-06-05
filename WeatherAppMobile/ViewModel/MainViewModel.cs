namespace WeatherAppMobile.ViewModel;
public partial class MainViewModel : BaseViewModel
{
    //private IConnectivity connectivity;

    public MainViewModel()
    {

    }

    //public MainViewModel(IConnectivity connectivity)
    //{
    //    this.connectivity = connectivity;
    //}

    //[RelayCommand]
    //async Task GetWeather()
    //{
    //    if(IsBusy) return;

    //    try
    //    {
    //        if (connectivity.NetworkAccess != NetworkAccess.Internet)
    //        {
    //            return;
    //        }

    //        IsBusy = true;



    //        var weatherData = await WeatherDtmcPortfolioHTTPService.GetWeather();
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        IsBusy = false;
    //    }
    //}
}
