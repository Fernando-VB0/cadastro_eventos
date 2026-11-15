using cadastro_eventos.Models;

namespace cadastro_eventos;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento meuEvento = new Evento
            {
                NomeEvento = txt_nome.Text,
                LocalEvento = txt_local.Text,
                NumeroParticipantes = Convert.ToInt32(txt_participantes.Text),
                CustoPorParticipante = Convert.ToDouble(txt_custo.Text),
                DataInicio = dtpck_inicio.Date ?? DateTime.Today,
                DataTermino = dtpck_termino.Date ?? DateTime.Today
            };

            await Navigation.PushAsync(new EventoContratado()
            {
                BindingContext = meuEvento
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", "Preencha todos os campos corretamente! Erro: " + ex.Message, "OK");
        }
    }
}