namespace JC_ExamenP2;

public partial class MainPage : ContentPage
{
	int count = 0;
    public string ContenidoSeleccionado { get; set; }
    public RadioButton radioButton1 { get; set; }
    public RadioButton radioButton2 { get; set; }
    public RadioButton radioButton3 { get; set; }


    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
        RadioButton radioButton1 = new RadioButton { Content = "3" };
        RadioButton radioButton2 = new RadioButton { Content = "5" };
        RadioButton radioButton3 = new RadioButton { Content = "10", IsChecked = true };

        radioButton1.CheckedChanged += RadioButton_CheckedChanged;
        radioButton2.CheckedChanged += RadioButton_CheckedChanged;
        radioButton3.CheckedChanged += RadioButton_CheckedChanged;

        StackLayout stackLayout = this.FindByName<StackLayout>("miStackLayout");


        // Agrega los RadioButtons al StackLayout
        stackLayout.Children.Add(radioButton1);
        stackLayout.Children.Add(radioButton2);
        stackLayout.Children.Add(radioButton3);

        btnConfirmar.Clicked += BtnConfirmar_Clicked;
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton radioButton = (RadioButton)sender;

        if (radioButton.IsChecked)
        {
            ContenidoSeleccionado = (string)radioButton.Content;
            // Hacer algo con el contenido seleccionado

            // Actualizar la interfaz de usuario
            OnPropertyChanged(nameof(ContenidoSeleccionado));
        }
    }

    private async void BtnConfirmar_Clicked(object sender, EventArgs e)
    {
        // Validar los campos del RadioButton
        if (radioButton1.IsChecked|| radioButton2.IsChecked|| radioButton3.IsChecked)
        {
            // Mostrar mensaje de confirmación
            bool respuesta = await DisplayAlert("Confirmación", "¿Estás seguro de confirmar?", "Sí", "No");

            if (respuesta)
            {
                // El usuario seleccionó "Sí"
                // Realizar acciones adicionales aquí
            }
            else
            {
                // El usuario seleccionó "No" o cerró el mensaje de confirmación
                // Realizar acciones adicionales aquí si es necesario
            }
        }
        else
        {
            // El RadioButton no está seleccionado
            // Realizar acciones adicionales aquí si es necesario
        }
    }
}
