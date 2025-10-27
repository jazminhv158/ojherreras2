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

    private async void Button_Clicked(object sender, EventArgs e)
    {

    }
}