namespace TiendaSmart.Views;
using TiendaSmart.Model;
using TiendaSmart.Conexion;

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
