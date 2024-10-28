using NubeCRUD.Model;
using NubeCRUD.Conexion;
namespace NubeCRUD.Views;

public partial class AddProductoPage : ContentPage
{

    FirebaseConexion firebaseConexion = new FirebaseConexion();


    public AddProductoPage()
    {
        InitializeComponent();
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        var producto = new Producto()
        {
            Nombre = NombreEntry.Text,
            Descripcion = DescripcionEntry.Text,
            Precio = decimal.Parse(PrecioEntry.Text),
        };

        await firebaseConexion.AddProducto(producto);
        await DisplayAlert("Exito", "Producto agregado", "ok");
        await Navigation.PopAsync();
    }
}