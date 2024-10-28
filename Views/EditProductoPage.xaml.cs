namespace TiendaSmart.Views;
using TiendaSmart.Model;
using TiendaSmart.Conexion;
using System.Text.RegularExpressions;


public partial class EditProductoPage : ContentPage
{
    FirebaseConexion firebaseConexion = new FirebaseConexion();
    private Producto producto;

    // Constructor que recibe el producto
    public EditProductoPage(Producto producto)
    {
        InitializeComponent();
        this.producto = producto;

        // Cargar datos del producto en los campos de entrada
        if (producto != null)
        {
            NombreEntry.Text = producto.Nombre;
            DescripcionEntry.Text = producto.Descripcion;
            PrecioEntry.Text = producto.Precio.ToString();
        }
    }

    private async void OnUpdateProductClicked(object sender, EventArgs e)
    {
        // Verificar si los campos están vacíos
        if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
            string.IsNullOrWhiteSpace(DescripcionEntry.Text) ||
            string.IsNullOrWhiteSpace(PrecioEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, rellena todos los campos antes de actualizar el producto", "Ok");
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
            await DisplayAlert("Error", "El campo 'Precio' solo pued contener letras", "Ok");
            return;
        }

        // Actualizar los datos del producto
        producto.Nombre = NombreEntry.Text;
        producto.Descripcion = DescripcionEntry.Text;
        producto.Precio = decimal.Parse(PrecioEntry.Text);

        // Enviar los datos actualizados a Firebase
        await firebaseConexion.UpdateProducto(producto.Id, producto);
        await DisplayAlert("Éxito", "Producto actualizado", "OK");

        // Regresar a la página anterior
        await Navigation.PopAsync();
    }
}
