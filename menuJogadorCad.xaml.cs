using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorCad : ContentPage
{
	public menuJogadorCad()
	{
		InitializeComponent();
        // Define o BindingContext da p�gina para uma nova inst�ncia da classe JogadorViewModel
        BindingContext = new JogadorViewModel();
    }

    // Evento Clicked do bot�o para adicionar o jogador � lista de jogadores usando as propriedades
    // Nome e Nota do ViewModel
    private async void cadastrarJogador(object sender, EventArgs e)
    {
        //Quando o usu�rio clicar em "Cadastrar Jogador", o jogador � salvo na lista
        //Exibe o alerta que a opera��o foi bem sucedida
        //Para fazer Vincula��o de Dados do Bot�o que foi definido na View, precisamos
        //definir uma BindingContext

        // Obt�m o ViewModel associado � p�gina
        var viewModel = BindingContext as JogadorViewModel;

        // Executa o comando EnviarCommand do ViewModel
        if (viewModel.EnviarCommand.CanExecute(null))
            viewModel.EnviarCommand.Execute(null);

        await DisplayAlert("Alerta", "Jogador Inclu�do com Sucesso!", "Concluir");

       //Falta implementar o tratamento de erro para caso o nome do jogador j� exista 
       //na lista
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            int notaJogador = int.Parse((string)picker.ItemsSource[selectedIndex]);
            // Atribua a nota do jogador aqui
            var viewModel = (JogadorViewModel)BindingContext;
            viewModel.NotaJogador = notaJogador;
        }
    }

}