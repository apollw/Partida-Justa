using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorEdicao : ContentPage
{
	public menuJogadorEdicao()
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

        if (viewModel.ObjJogador.Nome == string.Empty)
            await DisplayAlert("Alerta", "O nome do Jogador n�o foi informado!", "Concluir");

        else if (viewModel.ObjJogador.Nota == 0)
            await DisplayAlert("Alerta", "A nota do Jogador n�o foi informada!", "Concluir");

        else if (viewModel.Repeticao == true)
        {
            await DisplayAlert("Alerta", "Jogador Inserido j� existe!", "Concluir");
            viewModel.Repeticao = false; //Procura de novo
        }

        else
        {
            await DisplayAlert("Alerta", "Jogador Editado com Sucesso!", "Concluir");

            viewModel.NomeJogador = string.Empty;
            viewModel.NotaJogador = 0;
            picker.SelectedIndex = -1;

        }
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            int notaJogador = int.Parse((string)picker.ItemsSource[selectedIndex]);

            // Atribue a nota do jogador aqui
            var viewModel = (JogadorViewModel)BindingContext;
            viewModel.NotaJogador = notaJogador;
        }
    }

}