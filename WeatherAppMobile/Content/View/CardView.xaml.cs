namespace WeatherAppMobile.Content.View;

public partial class CardView : ContentView
{
    public static readonly BindableProperty CardLabelTitleProperty = BindableProperty.Create(
        nameof(CardLabelTitle),
        typeof(string),
        typeof(CardView),
        string.Empty);

    public static readonly BindableProperty CardLabelSubTitleProperty = BindableProperty.Create(
        nameof(CardLabelSubTitle),
        typeof(string),
        typeof(CardView),
        string.Empty);

    public static readonly BindableProperty CardLabelTextProperty = BindableProperty.Create(
        nameof(CardLabelText),
        typeof(string),
        typeof(CardView),
        string.Empty);

    public static readonly BindableProperty CardChildrenStackLayoutProperty = BindableProperty.Create(
        nameof(CardChildrenStackLayout),
        typeof(StackLayout),
        typeof(CardView),
        new StackLayout());

    public string CardLabelTitle
    {
        get => (string)GetValue(CardView.CardLabelTitleProperty);
        set => SetValue(CardView.CardLabelTitleProperty, value);
    }

    public string CardLabelSubTitle
    {
        get => (string)GetValue(CardView.CardLabelSubTitleProperty);
        set => SetValue(CardView.CardLabelSubTitleProperty, value);
    }

    public string CardLabelText
    {
        get => (string)GetValue(CardView.CardLabelTextProperty);
        set => SetValue(CardView.CardLabelTextProperty, value);
    }

    public StackLayout CardChildren
    {
        get => (StackLayout)GetValue(CardView.CardChildrenStackLayoutProperty);
        set => SetValue(CardView.CardChildrenStackLayoutProperty, value);
    }

    public CardView()
    {
        InitializeComponent();
    }
}