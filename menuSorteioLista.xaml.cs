using Microsoft.UI.Xaml.Controls;
using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuSorteioLista : ContentPage
{
	public menuSorteioLista()
	{
		InitializeComponent();
        var viewModel = new TimeViewModel();
        BindingContext = viewModel;

        // Chama a fun��o OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnCarregarTimes();

        //var teamBox = new TeamBox(); // TeamBox � o nome da sua classe que cont�m o c�digo XAML acima
        //teamBox.BindingContext = viewModel.Times;
        //Content = teamBox;
    }
          

    //private void OnButtonClicked(object sender, EventArgs e)
    //{
    //    // Acesse a cole��o Times aqui e exiba seus elementos
    //    foreach (var time in Times)
    //    {
    //        Console.WriteLine("Time: " + time.NomeTime);
    //        Console.WriteLine("Jogadores: ");
    //        foreach (var jogador in time.JogadorTime)
    //        {
    //            Console.WriteLine(jogador.NomeJogador + " - Nota: " + jogador.NotaJogador);
    //        }
    //    }
    //}





}