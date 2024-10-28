using TiendaSmart.Model;
using TiendaSmart.Conexion;

namespace TiendaSmart.Views
{
    public partial class ListProductoPage : ContentPage
    {
        FirebaseConexion firebaseConexion = new FirebaseConexion();

        public ListProductoPage()
        {
            InitializeComponent();
            LoadProduct(GetProductsListViews());
        }

        private ListView GetProductsListViews()
        {
            return ProductsListViews;
        }

        private async void LoadProduct(ListView productsListViews)
        {
            try
            {
                var producto = await firebaseConexion.GetAllProductos();
                productsListViews.ItemsSource = producto;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudieron cargar los productos: {ex.Message}", "Ok");
            }
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return; // Prevenir acci�n si no hay elemento seleccionado

            var producto = e.Item as Producto; // Aseg�rate de que este es el tipo correcto

            var action = await DisplayActionSheet("Seleccione una acci�n", "Cancelar", null, "Editar", "Eliminar");

            if (action == "Editar")
            {
                await Navigation.PushAsync(new EditProductoPage(producto));
            }
            else if (action == "Eliminar")
            {
                // Mostrar alerta de confirmaci�n
                bool confirmDelete = await DisplayAlert("Confirmar", "�Est� seguro de que desea eliminar este producto?", "S�", "No");
                if (confirmDelete)
                {
                    // Realizar la eliminaci�n
                    await firebaseConexion.DeleteProducto(producto.Id);

                    LoadProduct(GetProductsListViews()); // Recargar productos despu�s de eliminar uno
                }
            }

            // Deseleccionar el elemento
            ((ListView)sender).SelectedItem = null;
        }
    }
}
