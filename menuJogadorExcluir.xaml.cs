using Partida_Justa.Models;
namespace Partida_Justa;

public partial class menuJogadorExcluir : ContentPage
{
	public menuJogadorExcluir()
	{
        InitializeComponent();
    }

    private async void apagarLista(object sender, EventArgs e)
    {
        // Define o BindingContext da p�gina para uma nova inst�ncia da classe JogadorViewModel
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

       bool answer = await DisplayAlert("Alerta", "Tem certeza que deseja limpar a lista?", "Sim", "N�o");
        if (answer)
        {
            bool answer2 = await DisplayAlert("Alerta", "A exclus�o n�o pode ser desfeita. Deseja continuar?", "Sim", "N�o");
            if (answer2)
            {
                viewModel.OnExcluir();
                await DisplayAlert("Alerta", "Lista Apagada com Sucesso!", "Concluir");
                await Navigation.PopAsync();
            }
        }
        else
        {
            await DisplayAlert("Alerta", "A lista n�o foi alterada", "Concluir");
            await Navigation.PopAsync();
        }
    }

}