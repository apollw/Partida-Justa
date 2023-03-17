namespace Partida_Justa;

public partial class menuJogadorCad : ContentPage
{
	public menuJogadorCad()
	{
		InitializeComponent();
	}

    private async void cadastrarJogador(object sender, EventArgs e)
    {
        //Quando o usu�rio clicar em "Cadastrar Jogador", o jogador � salvo na lista
        //Exibe o alerta que a opera��o foi bem sucedida
        //string nome = Entry.Text;

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

        if(value>=0&&value<1)
            displayLabel.Text = String.Format("N�vel 1");
        if (value >= 1 && value <2)
            displayLabel.Text = String.Format("N�vel 2");
        if (value >= 2 && value <3)
            displayLabel.Text = String.Format("N�vel 3");
        if (value >= 3 && value <4)
            displayLabel.Text = String.Format("N�vel 4");
        if (value >= 4 && value <= 5)
            displayLabel.Text = String.Format("N�vel 5");

    }
}