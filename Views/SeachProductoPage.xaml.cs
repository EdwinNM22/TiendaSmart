using TiendaSmart.Conexion;
using TiendaSmart.Views;
using TiendaSmart.Model;


namespace TiendaSmart.Views;

public partial class SearchProductPage : ContentPage
{
    FirebaseConexion firebaseConexion = new FirebaseConexion();
    public SearchProductPage()
    {
        InitializeComponent();
    }


    private async void OnSearchProductClicked(object sender, EventArgs e)
    {
        string searchTerm = SearchEntry.Text;
        var productos = await firebaseConexion.GetAllProductos();
        var filteredProductos = productos.Where(p => p.Nombre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        ResultsListViews.ItemsSource = filteredProductos;


    }
}