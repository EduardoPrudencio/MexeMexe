using MexeMexe.Aprexentacao.Wpf.ViewModel;
using System.Windows;

namespace MexeMexe.Aprexentacao.Wpf.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        public GameView()
        {
            InitializeComponent();

            DataContext = new GameViewModel();

            var t = ((GameViewModel)DataContext).StackCompraCartas.Children[0];

            ((GameViewModel)DataContext).StackCompraCartas.Children.Remove(t);

            stackAreaCompraCarta.Children.Add(t);
        }
    }
}
