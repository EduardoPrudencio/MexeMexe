using System;
using System.Windows.Input;

namespace MexeMexe.Apresentacao.Wpf.Comandos
{
    public class PedirCartaCommand : ICommand
    {

        public event EventHandler OnPedirCartas;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InformarPedirCartas(EventArgs.Empty);
        }

        private void InformarPedirCartas(EventArgs args)
        {
            OnPedirCartas(this, args);
        }
    }
}
