using System.Reflection;
using System.Text.Json;
using WeatherAppMobile.Content.View;
using WeatherAppMobile.Models.CombinedWeather;
using WeatherAppMobile.Options;

namespace WeatherAppMobile.Content.Page;

[QueryProperty(nameof(WeatherData), "WeatherData")]
public partial class DisplayWeatherResultsPage : ContentPage
{
    public CombinedWeatherDataModel WeatherData
    {
        set
        {
            DisplayWeatherData(value);
        }
    }

    public DisplayWeatherResultsPage()
    {
        InitializeComponent();
    }

    private void DisplayWeatherData(CombinedWeatherDataModel weatherData)
    {
        DisplayWeatherDataInCards(weatherData);

        DisplayWeatherDataInRaw(weatherData);
    }

    private void DisplayWeatherDataInCards(CombinedWeatherDataModel weatherData)
    {
        WeatherDataCards.Clear();

        var stackLayout = new StackLayout();

        WeatherDataCards.Children.Add(stackLayout);

        var weatherDataProperties = typeof(CombinedWeatherDataModel).GetProperties();

        PropertyLoop(weatherData, weatherDataProperties, stackLayout);
    }

    private void PropertyLoop(
        Object weatherData,
        PropertyInfo[] propertyInfoArray,
        StackLayout stackLayout)
    {
        foreach (var wdProperty in propertyInfoArray)
        {
            HandlePropertyInfo(weatherData, wdProperty, stackLayout);
        }
    }

    private void HandlePropertyInfo(
        Object weatherData,
        PropertyInfo propertyInfo,
        StackLayout stackLayout)
    {
        switch (propertyInfo.PropertyType.BaseType?.Name)
        {
            case "ValueType":
                InsertLabel(weatherData, propertyInfo, stackLayout);
                break;
            default:
                switch (propertyInfo.PropertyType.Name)
                {
                    case "String":
                        InsertLabel(weatherData, propertyInfo, stackLayout);
                        break;
                    default:

                        InsertCard(weatherData, propertyInfo, stackLayout);
                        break;
                }
                break;
        }
    }

    private void InsertCard(
        Object weatherData,
        PropertyInfo propertyInfo,
        StackLayout stackLayout)
    {
        if (propertyInfo is not null && weatherData is not null)
        {
            var propertyValue = propertyInfo.GetValue(weatherData);
            var cardView = new CardView
            {
                CardLabelTitle = propertyInfo.Name,
            };
            stackLayout.Children.Add(cardView);

            if (propertyValue is not null)
            {
                var properties = propertyValue.GetType().GetProperties();
                PropertyLoop(propertyValue, properties, cardView.CardChildren);
            }
        }
    }

    private void InsertLabel(
        Object weatherData,
        PropertyInfo propertyInfo,
        StackLayout stackLayout)
    {
        if (propertyInfo is not null && weatherData is not null)
        {
            var propertyValue = propertyInfo.GetValue(weatherData);
            var labelWithText = new LabelWithText
            {
                LabelTitle = propertyInfo.Name,
                LabelText = propertyValue is null ? "" : propertyInfo.PropertyType.Name switch
                {
                    "Object" => JsonSerializer.Serialize(propertyValue),
                    _ => propertyValue.ToString() ?? ""
                }
            };

            stackLayout.Children.Add(labelWithText);
        }

    }

    private void DisplayWeatherDataInRaw(CombinedWeatherDataModel weatherData)
    {
        WeatherJsonData.Text = JsonSerializer.Serialize(weatherData, DefaultGlobalOptions.DefaultSerialize);
    }
}