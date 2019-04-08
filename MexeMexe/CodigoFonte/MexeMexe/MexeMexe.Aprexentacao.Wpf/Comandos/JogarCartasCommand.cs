using System;
using System.Windows.Input;

namespace MexeMexe.Apresentacao.Wpf.Comandos
{
    public class JogarCartasCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
