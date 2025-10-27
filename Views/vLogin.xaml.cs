using System.Threading.Tasks;

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

    private async Task btnIngresar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string usuario = txtUsuario.Text?.Trim();
            string contrasena = txtContrasena.Text?.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                await DisplayAlert("Error", "Debe ingresar usuario y contraseña correctos", "Ok");
                return;
            }

            if (usuariosValidos.TryGetValue(usuario, out string passwordcorrecto) && passwordcorrecto == contrasena)
            {
                await DisplayAlert("Acceso concedido", $"Bienvenido {usuario}", "continuar");
                await Navigation.PushAsync(new vInicio());
            }
            else
            {
                await DisplayAlert("error", "Usuario o contraseña incorrectos", "ok");
            }
        }

        catch (Exception ex) {
            Console.WriteLine($"Error en login: {ex.Message}");
            await DisplayAlert("Error", "ocurrio un problema", "ok");
        }

    }
}