namespace ojherreras2.Views;

public partial class vLogin : ContentPage
{
    private readonly Dictionary<string, string> usuariosValidos = new()
    {
        {"Carlos","carlos123" },
        {"Ana","ana123" },
        {"Jose","jose123" }
    };

    public vLogin()
    {
        InitializeComponent();
    }

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string usuario = txtUsuario.Text?.Trim();
            string contrasena = txtContrasena.Text?.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                await DisplayAlert("Error", "Debe ingresar usuario y contraseña", "OK");
                return;
            }

            // Validar usuario y contraseña correctos
            if (usuariosValidos.TryGetValue(usuario, out string passwordCorrecto) && passwordCorrecto == contrasena)
            {
                await DisplayAlert("Acceso concedido", $"Bienvenido {usuario}", "Continuar");
                Navigation.PushAsync(new vInicio(usuario, contrasena));
                
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en login: {ex.Message}");
           
        }
    }


}