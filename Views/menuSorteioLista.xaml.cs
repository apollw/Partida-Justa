using Partida_Justa.Models;
namespace Partida_Justa;

public partial class menuSorteioLista : ContentPage
{
	public menuSorteioLista()
	{
        // Cria uma nova inst�ncia do ViewModel de Time
        var viewModel = new TimeViewModel();

        // Chama a fun��o OnCarregarTimes() para carregar os dados do arquivo JSON
        viewModel.OnCarregarTimes();

        // Define o ViewModel como contexto de dados para a p�gina
        BindingContext = viewModel;

        // Inicializa a p�gina e carrega os componentes visuais
        InitializeComponent();        

        /*Em geral, no processo de inicializa��o de uma p�gina, primeiro precisamos carregar os dados que ser�o exibidos nela. 
         * Neste caso, os dados que desejamos exibir s�o os times sorteados, que s�o carregados por meio da chamada ao m�todo 
         * OnCarregarTimes() da inst�ncia viewModel da classe TimeViewModel. Ent�o, ao chamar viewModel.OnCarregarTimes() antes
         * de inicializar o componente, estamos garantindo que os dados estar�o dispon�veis quando o componente for criado e configurado. 
         * Ap�s o carregamento dos dados, � seguro inicializar o componente por meio da chamada ao m�todo InitializeComponent(), 
         * que � respons�vel por carregar o arquivo XAML e renderizar a interface de usu�rio. 
         * Dessa forma, garantimos que os dados ser�o exibidos corretamente na tela, uma vez que foram carregados antes da 
         * inicializa��o do componente que os exibe.*/
    }
}