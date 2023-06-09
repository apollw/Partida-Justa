using Microsoft.Extensions.Options;
using Partida_Justa.Models;
using Partida_Justa.Views;

namespace Partida_Justa;

public partial class menuSorteioSort : ContentPage
{
	public menuSorteioSort()
	{
		InitializeComponent();
        BindingContext = new TimeViewModel();
    }

    private async void sortearTimes(object sender, EventArgs e)
    {
        // Obt�m o ViewModel associado � p�gina
        TimeViewModel viewModel = BindingContext as TimeViewModel;

        // Executa o comando EnviarCommand do ViewModel
        if (viewModel.SortearCommand.CanExecute(null))
            viewModel.SortearCommand.Execute(null);

        if (viewModel.Criado == true)
        {
            await DisplayAlert("Alerta", "Times criados com sucesso!", "Concluir");
            await Navigation.PushAsync(new menuSorteioLista());
        }
        else
        {
            await DisplayAlert("Alerta", "N�mero Insuficiente de Jogadores", "Fechar");
            await Navigation.PopAsync();
        }
    }

    //void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    var picker = (Picker)sender;
    //    int selectedIndex = picker.SelectedIndex;

    //    if (selectedIndex != -1)
    //    {
    //        int valor = int.Parse((string)picker.ItemsSource[selectedIndex]);

    //        // Atribue a nota do jogador aqui
    //        var viewModel = (TimeViewModel)BindingContext;

    //        if (valor != 0)
    //            viewModel.tamanhoEquipe = valor;
    //    }
    //}

    void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        int valor = (int)e.NewValue;
        // Atribue o n�mero de Jogadores por Equipe aqui
        var viewModel = (TimeViewModel)BindingContext;
        if (valor != 0)
            viewModel.tamanhoEquipe = valor;
    }

}