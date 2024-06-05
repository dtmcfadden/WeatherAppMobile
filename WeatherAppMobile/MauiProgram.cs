using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace WeatherAppMobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        //builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddAppServices();

        return builder.Build();
    }
}
