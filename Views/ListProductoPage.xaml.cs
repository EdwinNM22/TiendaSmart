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
            if (e.Item == null) return; // Prevenir acción si no hay elemento seleccionado

            var producto = e.Item as Producto; // Asegúrate de que este es el tipo correcto

            var action = await DisplayActionSheet("Seleccione una acción", "Cancelar", null, "Editar", "Eliminar");

            if (action == "Editar")
            {
                await Navigation.PushAsync(new EditProductoPage(producto));
            }
            else if (action == "Eliminar")
            {
                // Mostrar alerta de confirmación
                bool confirmDelete = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar este producto?", "Sí", "No");
                if (confirmDelete)
                {
                    // Realizar la eliminación
                    await firebaseConexion.DeleteProducto(producto.Id);

                    LoadProduct(GetProductsListViews()); // Recargar productos después de eliminar uno
                }
            }

            // Deseleccionar el elemento
            ((ListView)sender).SelectedItem = null;
        }
    }
}
