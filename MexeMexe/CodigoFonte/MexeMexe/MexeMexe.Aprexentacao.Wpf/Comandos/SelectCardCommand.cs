using System;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

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

            imagem.Margin = new System.Windows.Thickness(0,0,0,0);

        }
    }
}
