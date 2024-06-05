using FluentValidation;
using WeatherAppMobile.Content.Page;
using WeatherAppMobile.Entities.Validators;
using WeatherAppMobile.Options;
using WeatherAppMobile.Services;
using WeatherAppMobile.ViewModel;

namespace WeatherAppMobile;
public static class RegisterAppServices
{
    private static readonly SocketsHttpHandler defaultSocketHandler = new()
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(5),
    };

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddPageView();

        services.AddConfigureOptions();

        services.AddValidators();

        services.AddHTTPServices();

        //services.AddHttpContextAccessor();

        return services;
    }

    private static IServiceCollection AddPageView(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddSingleton<MainViewModel>();

        services.AddTransient<DisplayWeatherResultsPage>();

        return services;
    }

    private static IServiceCollection AddConfigureOptions(this IServiceCollection services)
    {
        services.Configure<EnvironmentOptions>(options =>
        {
            //var owSection = weatherAPIConfiguration.GetSection("openweather-apikey");
            //if (owSection.Value != null)
            //    options.OpenWeatherApiKey = owSection.Value;

            //var waSection = weatherAPIConfiguration.GetSection("weatherapi-apikey");
            //if (waSection.Value != null)
            //    options.WeatherAPIApiKey = waSection.Value;

            //var weatherConnectionString = weatherAPIConfiguration.GetSection("weather-connectionstring");
            //if (weatherConnectionString.Value != null)
            //    options.WeatherConnectionString = weatherConnectionString.Value;
        });

        return services;
    }

    private static IServiceCollection AddHTTPServices(this IServiceCollection services)
    {
        services.AddHttpClient<WeatherDtmcPortfolioHTTPService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://weather.dtmcportfolio.info/");
        })
            .ConfigurePrimaryHttpMessageHandler(() => defaultSocketHandler)
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LatLongEntityValidator>();
        services.AddValidatorsFromAssemblyContaining<LocationEntityValidator>();

        return services;
    }
}

