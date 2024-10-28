
using TiendaSmart.Views;

    namespace TiendaSmart.Views;

    public partial class LoginPage : ContentPage
    {


        public LoginPage()
        {
            InitializeComponent();
        }

        private async void IniciarButton_Clicked(object sender, EventArgs e)
        {
            string nombre = UsuarioEntry.Text;
            string contra = ContraEntry.Text;

            if (nombre == "user" && contra == "123")
            {
                await DisplayAlert("Inicio de sesion", "El inicio de sesion fue un exito", "Aceptar");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Inicio de sesion", "Fallo el inicio", "Aceptar");
            }

        }
    }


