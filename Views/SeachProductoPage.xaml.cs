using NubeCRUD.Conexion;
using NubeCRUD.Views;
using NubeCRUD.Model;


namespace NubeCRUD.Views;

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