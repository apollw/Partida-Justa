namespace Partida_Justa;

public partial class MenuJogador : ContentPage
{
	public MenuJogador()
	{
		InitializeComponent();
	}

    //Cria��o de Eventos Ass�ncronos

    private async void MenuCadJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorCad());

    }

    private async void MenuExcluirJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorExcluir());
    }

    private async void MenuEditarJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorEditar());
    }

    private async void MenuListarJogador(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new menuJogadorLista());
    }

}