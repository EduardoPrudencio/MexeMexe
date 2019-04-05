using MexeMexe.Aprexentacao.Wpf.ViewModel;
using System;
using System.Windows.Input;

namespace MexeMexe.Aprexentacao.Wpf.Comandos
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
                if (_gameViewModel.VerificarSePodeAdicionarCarta())
                {
                    imagem.Margin = new System.Windows.Thickness(10, -50, 0, 0);
                    _gameViewModel.AdcionarCartaParaSerJogada(imagem.Name);
                }
                else
                {
                    _gameViewModel.ShowMessage("As cartas selecionadas não podem ser descartadas porque não atendem às regras do jogo. Por favor, monte outra sequência.");
                }
            }
        }
    }
}
