using MexeMexe.Apresentacao.Wpf.ViewModel;
using System;
using System.Windows.Input;

namespace MexeMexe.Apresentacao.Wpf.Comandos
{
    public class JogarCartasCommand : ICommand
    {
        GameViewModel _gameViewModel;

        public JogarCartasCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _gameViewModel.DescratarCartas();
        }
    }
}
