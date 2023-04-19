using Newtonsoft.Json;
using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa.Views;

public partial class menuJogadorEdicao : ContentPage
{
    private ModelJogador _jogador;

    //JogadorViewModel viewModel = new JogadorViewModel();


    public menuJogadorEdicao(ModelJogador jogador)
    {
        InitializeComponent();

        //// Define o BindingContext da p�gina para uma nova inst�ncia da classe JogadorViewModel
        //BindingContext = new JogadorViewModel();
        //BindingContext = viewModel;

        // Salva a refer�ncia ao jogador
        _jogador = jogador;
        // Define o contexto de vincula��o para a p�gina
        BindingContext = _jogador;

    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        // Obt�m o ViewModel associado � p�gina
        JogadorViewModel viewModel = BindingContext as JogadorViewModel;
        bool confirmado = false;

        if (viewModel.ObjJogador.Nome == string.Empty)
            await DisplayAlert("Alerta", "O nome do Jogador n�o foi informado!", "Concluir");
        else if (viewModel.ObjJogador.Nota == 0)
            await DisplayAlert("Alerta", "A nota do Jogador n�o foi informada!", "Concluir");
        else
        {
            // Salva as altera��es aqui
            _jogador.Nome = entry.Text;
            //_jogador.Nota = viewModel.NotaJogador;

            ////Salva as altera��es
            //var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
            ////Serializa a lista atualizada de volta para uma string JSON
            //string json = JsonConvert.SerializeObject(Jogadores);
            //// Salva a string JSON atualizada no arquivo
            //File.WriteAllText(filePath, json);

            await DisplayAlert("Alerta", "Jogador Editado com Sucesso!", "Concluir");
            viewModel.NomeJogador = string.Empty;
            viewModel.NotaJogador = 0;
            picker.SelectedIndex = -1;
            confirmado = true;
        }

        if (confirmado == true)
            await Navigation.PopModalAsync();
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            int notaJogador = int.Parse((string)picker.ItemsSource[selectedIndex]);

            // Atribue a nota do jogador aqui
            //var viewModel = (JogadorViewModel)BindingContext;
            //viewModel.NotaJogador = notaJogador;

            _jogador.Nota = notaJogador;
        }
    }
}