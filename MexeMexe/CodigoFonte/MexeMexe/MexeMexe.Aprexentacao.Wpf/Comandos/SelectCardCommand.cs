using System;
using System.Windows.Input;

namespace MexeMexe.Aprexentacao.Wpf.Comandos
{
    public class SelectCardCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SelectCardCommand()
        { 

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var imagem = parameter as System.Windows.Controls.Image;

            if (imagem.Margin.Top == -50)
                imagem.Margin = new System.Windows.Thickness(10,0,0,0);
            else
                imagem.Margin = new System.Windows.Thickness(10, -50, 0, 0);

        }
    }
}
