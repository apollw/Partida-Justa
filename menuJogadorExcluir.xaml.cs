using Partida_Justa.Models;
namespace Partida_Justa;

public partial class menuJogadorExcluir : ContentPage
{
	public menuJogadorExcluir()
	{

        InitializeComponent();
        // Define o BindingContext da p�gina para uma nova inst�ncia da classe JogadorViewModel
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;
    }


    // Evento Clicked do bot�o para adicionar o jogador � lista de jogadores usando as propriedades
    // Nome e Nota do ViewModel
    private async void excluirJogador(object sender, EventArgs e)
    {
        //Quando o usu�rio clicar em "Cadastrar Jogador", o jogador � salvo na lista
        //Exibe o alerta que a opera��o foi bem sucedida
        //Para fazer Vincula��o de Dados do Bot�o que foi definido na View, precisamos
        //definir uma BindingContext

        // Obt�m o ViewModel associado � p�gina
        var viewModel = BindingContext as JogadorViewModel;

        // Chama a fun��o OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnExcluir();

        await DisplayAlert("Alerta", "Lista Apagada com Sucesso!", "Concluir");

        //Falta implementar o tratamento de erro para caso o nome do jogador j� exista 
        //na lista
    }


}