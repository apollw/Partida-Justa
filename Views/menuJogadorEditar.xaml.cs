using Microsoft.Maui;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;
using Partida_Justa.Models;
using Partida_Justa.Views;
using System.Collections.ObjectModel;
using System.Xml.Linq;


namespace Partida_Justa;

public partial class menuJogadorEditar : ContentPage
{
    public ObservableCollection<ModelJogador> MyItems { get; set; }
    string nomeTemp;
    bool repetido; //Aponta que j� existe outro jogador com o nome editado

    public menuJogadorEditar()
    {
        
        var viewModel = new JogadorViewModel();
        BindingContext = viewModel;

        viewModel.OnCarregar();

        InitializeComponent();

        MyItems = new ObservableCollection<ModelJogador>();
        MyItems = viewModel.Jogadores;

        
    }

    void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var item = swipeItem.BindingContext as ModelJogador;
        MyItems.Remove(item);
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
        //Serializa a lista atualizada de volta para uma string JSON
        string json = JsonConvert.SerializeObject(MyItems);
        // Salva a string JSON atualizada no arquivo
        File.WriteAllText(filePath, json);
    }

    async void OnEditSwipeItemInvoked(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var jogador = swipeItem.BindingContext as ModelJogador;

        nomeTemp = jogador.Nome; //Guarda o nome que o m�todo traz da lista

        var nameEntry = new Entry
        {
            Text = jogador.Nome,
            Placeholder = "Insira o nome do jogador",
            WidthRequest = 250,
            TextColor = Color.FromRgb(0, 0, 0),
            PlaceholderColor = Color.FromRgb(217, 217, 217),
            BackgroundColor = Color.FromRgb(255, 255, 255),
            Keyboard = Keyboard.Default
        };

        var notaPicker = new Picker
        {
            Title = "Selecione a nota do Jogador",
            ItemsSource = new List<int> { 1, 2, 3, 4, 5 },
            SelectedItem = jogador.Nota,
            WidthRequest = 250,
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(255, 255, 255),
            HorizontalOptions = LayoutOptions.Center
        };

        var saveButton = new Button
        {
            Text = "Salvar",
            WidthRequest = 200,
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(255, 255, 255),
            BorderColor = Color.FromRgb(76, 199, 88),
            HorizontalOptions = LayoutOptions.Center
        };

        saveButton.Clicked += async (s, args) =>
        {
            //Primeiro verifica se o novo nome incluso n�o � de outro jogador incluso na lista
            repetido = false;
            foreach (ModelJogador element in MyItems)
            {
                if (element.Nome != nomeTemp && nameEntry.Text == element.Nome)
                {
                    //Se o jogador na lista for igual ao nome da Entry, por�m diferente do 
                    //nome trazido � Entry inicialmente, ent�o estamos tentando adicionar 
                    //outro jogador j� existente
                    repetido = true;
                    break;
                }
            }

            // Efetuar as altera��es aqui
            if (nameEntry.Text != String.Empty && repetido==false)
            {
                jogador.Nome = nameEntry.Text;
                jogador.Nota = (int)notaPicker.SelectedItem;             
                
                //Salva as altera��es
                var filePath = Path.Combine(FileSystem.AppDataDirectory, "jogadores.json");
                //Serializa a lista atualizada de volta para uma string JSON
                string json = JsonConvert.SerializeObject(MyItems);
                // Salva a string JSON atualizada no arquivo
                File.WriteAllText(filePath, json);

                await DisplayAlert("Alerta", "Jogador Editado com Sucesso!", "Concluir");
                await Navigation.PopAsync();
                                
            }
            else
            {
                await DisplayAlert("Alerta", "Jogador n�o foi Editado", "Fechar");
            }

        };

        var cancelButton = new Button
        {
            Text = "Cancelar",
            WidthRequest = 200,
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(249, 93, 46),
            BorderColor = Color.FromRgb(76, 199, 88),
            HorizontalOptions = LayoutOptions.Center
        };
        cancelButton.Clicked += async (s, args) =>
        {
         
            await Navigation.PopAsync();
        };

        var stackLayout = new StackLayout
        {
            Spacing = 5,
            Padding = new Thickness(35, 0),
            VerticalOptions = LayoutOptions.Center
        };
        stackLayout.Children.Add(new Image { WidthRequest = 200, Source = "imagem_cad.png" });
        stackLayout.Children.Add(new Label());
        stackLayout.Children.Add(nameEntry);
        stackLayout.Children.Add(new Label());
        stackLayout.Children.Add(notaPicker);
        stackLayout.Children.Add(saveButton);
        stackLayout.Children.Add(cancelButton);

        var scrollView = new ScrollView();
        scrollView.Content = stackLayout;

        var contentPage = new ContentPage
        {
            Content = scrollView,
            BackgroundImageSource = "background_moderno.png",
            Title = "Edi��o de Jogadores"
        };  

        await Navigation.PushAsync(contentPage);
    }

}
