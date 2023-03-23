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
        // Chama a fun��o OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnExcluir();
        await DisplayAlert("Alerta", "Lista Apagada com Sucesso!", "Concluir");

    }

    //private void excluirJogador(object sender, EventArgs e)
    //{
    //    // Obter o texto da caixa de texto
    //    //string nome = NomeEntry.Text; //Eu utilizo o nome associado � entry para dispara o evento

    //    //Ainda falta implementar um tratamento de erro caso o nome do jogador
    //    //n�o exista na lista de jogadores

    //    //Precisa-se implementar n�o um button, mas um search bar, que vai at� a lista
    //    //e resgata os valores
    //    //Se o n�mero estiver fora do intervalo, exibe alerta e n�o adiciona
    //}

}