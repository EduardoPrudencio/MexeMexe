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

            gameViewModel.MouAMAoDoJogador += GameViewModel_MouAMAoDoJogador;

            var t = ((GameViewModel)DataContext).StackCompraCartas.Children[0];

            ((GameViewModel)DataContext).StackCompraCartas.Children.Remove(t);

            stackAreaCompraCarta.Children.Add(t);

            MontarTela();
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
