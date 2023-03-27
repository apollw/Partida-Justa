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

       bool answer = await DisplayAlert("Alerta", "Tem certeza que quer excluir?", "Sim", "N�o");
        if (answer)
        {
            viewModel.OnExcluir();
            await DisplayAlert("Alerta", "Lista Apagada com Sucesso!", "Concluir");
        }
        else
            await Navigation.PopToRootAsync();
           //await Navigation.PushAsync(new menuJogadorEditar());

    }

    private async void apagarJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorExclusao());
    } 

}