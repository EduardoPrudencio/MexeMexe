using MexeMexe.Apresentacao.Wpf.ViewModel;
using System;
using System.Windows.Input;

namespace MexeMexe.Apresentacao.Wpf.Comandos
{
    public class SelectCardCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private GameViewModel _gameViewModel;

        public SelectCardCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var imagem = parameter as System.Windows.Controls.Image;


            if (imagem.Margin.Top == -50)
            {
                imagem.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                _gameViewModel.RemoverCartaParaSerJogada(imagem.Name);
            }
            else
            {
                imagem.Margin = new System.Windows.Thickness(10, -50, 0, 0);
                _gameViewModel.AdcionarCartaParaSerJogada(imagem.Name);


                if (!_gameViewModel.ValidarCartasParaJogar())
                {
                    _gameViewModel.ShowMessage("As cartas selecionadas não podem ser descartadas porque não atendem às regras do jogo. Por favor, monte outra sequência.");
                    _gameViewModel.RemoverCartaParaSerJogada(imagem.Name);
                    imagem.Margin = new System.Windows.Thickness(10, 0, 0, 0);
                }
            }
        }
    }
}
