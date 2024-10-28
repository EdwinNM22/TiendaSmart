using Firebase.Database;
using Firebase.Database.Query;
using TiendaSmart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaSmart.Conexion
{
    public class FirebaseConexion
    {
        private readonly FirebaseClient firebaseClient;

        public FirebaseConexion()
        {
            firebaseClient = new FirebaseClient("https://democrud-cfc33-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            var productos = await firebaseClient
                .Child("Productos")
                .OnceAsync<Producto>();

            return productos.Select(item => new Producto
            {
                Id = item.Key,
                Nombre = item.Object.Nombre,
                Descripcion = item.Object.Descripcion,
                Precio = item.Object.Precio,
            }).ToList();
        }

        public async Task AddProducto(Producto producto)
        {
            // Cambiado de PatchAsync a PostAsync para evitar sobreescribir productos
            await firebaseClient
                .Child("Productos")
                .PostAsync(producto);
        }

        public async Task UpdateProducto(string key, Producto producto)
        {
            await firebaseClient
                .Child("Productos")
                .Child(key)
                .PutAsync(producto);
        }

        public async Task DeleteProducto(string key)
        {
            await firebaseClient
                .Child("Productos")
                .Child(key)
                .DeleteAsync();
        }
    }
}
