using Partida_Justa.Models;
using System.Collections.ObjectModel;

namespace Partida_Justa;

public partial class menuJogadorLista : ContentPage
{
	public menuJogadorLista()
	{
        InitializeComponent();
        // Define o BindingContext da p�gina para uma nova inst�ncia da classe JogadorViewModel
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        // Chama a fun��o OnCarregar para carregar os dados do arquivo JSON
        viewModel.OnCarregar();
   
    }
}