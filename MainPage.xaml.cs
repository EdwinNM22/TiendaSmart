namespace TiendaSmart.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProductoPage());
    }

    private async void OnSearchProductClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SearchProductPage());
    }

    private async void OnListProductClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListProductoPage());
    }
}
