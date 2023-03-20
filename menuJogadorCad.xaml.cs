using Partida_Justa.Models;

namespace Partida_Justa;

public partial class menuJogadorCad : ContentPage
{
	public menuJogadorCad()
	{
		InitializeComponent();

        //Cria um objeto JogadorModel com o nome vazio
        JogadorModel jogador = new JogadorModel { Nome = "" };

        //Cria um objeto JogadorViewModel passando o objeto jogador como par�metro
        JogadorViewModel jogadorViewModel = new JogadorViewModel(jogador);

        //Vincula o objeto jogadorViewModel � propriedade BindingContext da View
        this.BindingContext = jogadorViewModel;

    }

    // Evento Clicked do bot�o para adicionar o jogador � lista de jogadores usando as propriedades
    // Nome e Nota do ViewModel
    private async void cadastrarJogador(object sender, EventArgs e)
    {
        //Quando o usu�rio clicar em "Cadastrar Jogador", o jogador � salvo na lista
        //Exibe o alerta que a opera��o foi bem sucedida


        //Para fazer Vincula��o de Dados do Bot�o que foi definido na View, precisamos
        //definir uma BindingContext

        await DisplayAlert("Alerta", "Jogador Inclu�do com Sucesso!", "Concluir");

       //Falta implementar o tratamento de erro para caso o nome do jogador j� exista 
       //na lista

    }

    //Elemento de Slider que altera os valores � medida que o usu�rio desliza o elemento na tela
    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;
        //Controle do Slider para responder a valores inteiros
        switch (value)
        {
            case >= 0 and < 1:
                displayLabel.Text = String.Format("N�vel 1");
                break;
            case >= 1 and < 2:
                displayLabel.Text = String.Format("N�vel 2");
                break;
            case >= 2 and < 3:
                displayLabel.Text = String.Format("N�vel 3");
                break;
            case >= 3 and < 4:
                displayLabel.Text = String.Format("N�vel 4");
                break;
            case >= 4 and <= 5:
                displayLabel.Text = String.Format("N�vel 5");
                break;
            default:
                // Voc� pode colocar algum c�digo para lidar com valores inv�lidos aqui
                break;
        }
    }
}