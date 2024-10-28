using TiendaSmart.Model;
using TiendaSmart.Conexion;
namespace TiendaSmart.Views;
using System.Text.RegularExpressions;


public partial class AddProductoPage : ContentPage
{

    FirebaseConexion firebaseConexion = new FirebaseConexion();


    public AddProductoPage()
    {
        InitializeComponent();
    }

    private async void OnAddProductClicked(object sender, EventArgs e)

    {    // Verificar si los campos están vacíos
        if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
            string.IsNullOrWhiteSpace(DescripcionEntry.Text) ||
            string.IsNullOrWhiteSpace(PrecioEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, rellena todos los campos antes de agregar el producto", "Ok");
            return; // Detener el proceso si algún campo está vacío
        }

        // Validar que el campo de Nombre solo contenga letras
        if (!Regex.IsMatch(NombreEntry.Text, @"^[a-zA-Z\s]+$"))
        {
            await DisplayAlert("Error", "El campo 'Nombre' solo puede contener letras", "Ok");
            return;
        }

        // Verificar si el precio es un número válido
        if (!decimal.TryParse(PrecioEntry.Text, out decimal precio))
        {
            await DisplayAlert("Error", "Por favor, ingresa un precio válido (solo números)", "Ok");
            return;
        }

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