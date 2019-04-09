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
            foreach (var carta in gameViewModel.CartasParaJogar)
            {
                stackCartasJogadas.Children.Add(carta);
            }
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

