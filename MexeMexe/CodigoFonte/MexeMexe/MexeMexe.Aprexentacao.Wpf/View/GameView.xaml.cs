using MexeMexe.Apresentacao.Wpf.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MexeMexe.Apresentacao.Wpf.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {

        GameViewModel gameViewModel;

        public GameView()
        {
            InitializeComponent();

            gameViewModel = new GameViewModel();

            DataContext = gameViewModel;

            gameViewModel.MudouAMaoDoJogador += GameViewModel_MouAMAoDoJogador;
            gameViewModel.PodeJogarCartasSelecionadas += GameViewModel_PodeJogarCartasSelecionadas;
            gameViewModel.NaoPodeJogarCartasSelecionadas += GameViewModel_NaoPodeJogarCartasSelecionadas;
            gameViewModel.HouveDescarte += GameViewModel_HouveDescarte;

            var t = ((GameViewModel)DataContext).StackCompraCartas.Children[0];

            ((GameViewModel)DataContext).StackCompraCartas.Children.Remove(t);

            stackAreaCompraCarta.Children.Add(t);

            MontarTela();
        }

        private void GameViewModel_HouveDescarte(object sender, System.EventArgs e)
        {
            int cont = 0;

            StackPanel stackGrupoDeCartas = new StackPanel();
            stackGrupoDeCartas.HorizontalAlignment = HorizontalAlignment.Left;
            Thickness posicaoStk = new Thickness(10, 0, 0, 0);
            stackGrupoDeCartas.Margin = posicaoStk;


            foreach (var carta in gameViewModel.CartasParaJogar)
            {
                if (cont > 0)
                {
                    Thickness posicao = new Thickness(0, -100, 0, 0);
                    carta.Margin = posicao;
                }

                stackGrupoDeCartas.Children.Add(carta);

                cont++;
            }

            stackCartasJogadas.Children.Add(stackGrupoDeCartas);

        }

        private void GameViewModel_NaoPodeJogarCartasSelecionadas(object sender, System.EventArgs e)
        {
            stackIndicadorPodeJogar.Visibility = Visibility.Hidden;
        }

        private void GameViewModel_PodeJogarCartasSelecionadas(object sender, System.EventArgs e)
        {
            stackIndicadorPodeJogar.Visibility = Visibility.Visible;
        }

        private void GameViewModel_MouAMAoDoJogador(object sender, System.EventArgs e)
        {
            MontarTela();
        }

        private void MontarTela()
        {
            stackAreaMaoJogador.Children.Clear();

            foreach (var cartaCriada in ((GameViewModel)DataContext).Cartas)
            {
                Image carta = cartaCriada;
                stackAreaMaoJogador.Children.Add(carta);
            }
        }

    }
}

