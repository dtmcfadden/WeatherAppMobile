namespace WeatherAppMobile.Content.View;

public partial class LabelWithText : ContentView
{
    public static readonly BindableProperty LabelTitleProperty = BindableProperty.Create(
        nameof(LabelTitle),
        typeof(string),
        typeof(LabelWithText),
        string.Empty);

    public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(
        nameof(LabelText),
        typeof(string),
        typeof(LabelWithText),
        string.Empty);

    public string LabelTitle
    {
        get => (string)GetValue(LabelWithText.LabelTitleProperty);
        set => SetValue(LabelWithText.LabelTitleProperty, value);
    }
    public string LabelText
    {
        get => (string)GetValue(LabelWithText.LabelTextProperty);
        set => SetValue(LabelWithText.LabelTextProperty, value);
    }

    public LabelWithText()
    {
        InitializeComponent();
    }
}