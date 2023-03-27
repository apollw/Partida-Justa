using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorEditar : ContentPage
{
    public menuJogadorEditar()
    {
        InitializeComponent();
        // Define o BindingContext da p�gina para uma nova inst�ncia da classe JogadorViewModel
        BindingContext = new JogadorViewModel();
    }


    private async void editarJogador(object sender, EventArgs e)
    {
        // Obt�m o ViewModel associado � p�gina
        JogadorViewModel viewModel = BindingContext as JogadorViewModel;

        // Executa o comando EnviarCommand do ViewModel
        if (viewModel.EnviarCommand.CanExecute(null))
            viewModel.EnviarCommand.Execute(null);

        viewModel.OnEditar();

        if (viewModel.ObjJogador.Nome == string.Empty)
            await DisplayAlert("Alerta", "O nome do Jogador n�o foi informado!", "Concluir");
        else if (viewModel.Encontrado == true)
        {
            await DisplayAlert("Alerta", "Jogador Encontrado!", "Concluir");
            await Navigation.PushAsync(new menuJogadorEdicao());
        }
        else
            await DisplayAlert("Alerta", "Jogador N�o Encontrado!", "Concluir");

    }
}