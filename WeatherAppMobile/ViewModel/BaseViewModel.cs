namespace WeatherAppMobile.ViewModel;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title = "Weather App";

    public bool IsNotBusy => !IsBusy;
}
