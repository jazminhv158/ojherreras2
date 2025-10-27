namespace ojherreras2.Views;

public partial class vInicio : ContentPage
{
	public vInicio()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        
        if (PickerEstudiantes.SelectedItem == null)
        {
            await DisplayAlert("Error", "Seleccione un estudiante.", "OK");
            return;
        }

        
        if (string.IsNullOrWhiteSpace(Seguimiento1.Text) ||
            string.IsNullOrWhiteSpace(Examen1.Text) ||
            string.IsNullOrWhiteSpace(Seguimiento2.Text) ||
            string.IsNullOrWhiteSpace(Examen2.Text))
        {
            await DisplayAlert("Error", "Ingrese todas las notas.", "OK");
            return;
        }

        // VALIDACION FORMATO Y RANGO
        if (!ValidarNota(Seguimiento1.Text) ||
            !ValidarNota(Examen1.Text) ||
            !ValidarNota(Seguimiento2.Text) ||
            !ValidarNota(Examen2.Text))
        {
            await DisplayAlert("Error", "Las notas deben ser numéricas, con máximo 2 dígitos y no mayores a 10.", "OK");
            return;
        }

        // CONVERTIR A DOUBLE
        double s1 = double.Parse(Seguimiento1.Text);
        double e1 = double.Parse(Examen1.Text);
        double s2 = double.Parse(Seguimiento2.Text);
        double e2 = double.Parse(Examen2.Text);

        // CALCULO DE CALIFICACIONES
        double parcial1 = (s1 * 0.3) + (e1 * 0.2);
        double parcial2 = (s2 * 0.3) + (e2 * 0.2);
        double notaFinal = parcial1 + parcial2;

        // CALULAR ESTADO
        string estadoFinal;
        if (notaFinal >= 7)
            estadoFinal = "APROBADO";
        else if (notaFinal >= 5 && notaFinal <= 6.9)
            estadoFinal = "COMPLEMENTARIO";
        else
            estadoFinal = "REPROBADO";

        // MOSTRAR RESULTADOS
        Parcial1.Text = parcial1.ToString("0.00");
        Parcial2.Text = parcial2.ToString("0.00");
        notafinal.Text = notaFinal.ToString("0.00");
        estado.Text = estadoFinal;

        // MOSTRAR ALERTA
        string mensaje =
            $"Estudiante: {PickerEstudiantes.SelectedItem}\n" +
            $"Fecha: {dfFecha.Date:dd/MM/yyyy}\n" +
            $"Parcial 1: {parcial1:0.00}\n" +
            $"Parcial 2: {parcial2:0.00}\n" +
            $"Nota Final: {notaFinal:0.00}\n" +
            $"Estado: {estadoFinal}";

        await DisplayAlert("Resultados", mensaje, "OK");

        // LIMPIAR CAMPOS
        LimpiarCampos();
    }

    // VALIDACION DE DATOS
    private bool ValidarNota(string texto)
    {
        if (texto.Length > 2) return false; // MAX 2 CARACTERES
        if (!double.TryParse(texto, out double valor)) return false; // VALIDAR DEBE SER NUMERO
        if (valor < 0 || valor > 10) return false; // VALIDAR RANGO VALIDO
        return true;
    }

    // VALIDAR LOS CAMPOS
    private void LimpiarCampos()
    {
        Seguimiento1.Text = string.Empty;
        Examen1.Text = string.Empty;
        Seguimiento2.Text = string.Empty;
        Examen2.Text = string.Empty;
        Parcial1.Text = "Nota Parcial 1";
        Parcial2.Text = "Nota Parcial 2";
        notafinal.Text = "Nota final";
        estado.Text = "Estado";
        PickerEstudiantes.SelectedItem = null;
        dfFecha.Date = DateTime.Today;
    }

}
