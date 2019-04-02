using MexeMexe.Aprexentacao.Wpf.Comandos;
using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;
using System.Windows;
using System.Windows.Input;

namespace MexeMexe.Aprexentacao.Wpf.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        Configuracao _config;
        Engine       _engine ;
        string       _cartas = string.Empty;
        Jogador player;

        private ICommand _selectCardCommand;

        string mao1 = string.Empty;
        string mao2 = string.Empty;
        string mao3 = string.Empty;
        string mao4 = string.Empty;
        string mao5 = string.Empty;
        string mao6 = string.Empty;
        string mao7 = string.Empty;
        string mao8 = string.Empty;
        string mao9 = string.Empty;
        string mao10 = string.Empty;
        string mao11 = string.Empty;

        public GameViewModel()
        {
            _config = new Configuracao("Jogador - 1", 9);
            _engine = new Engine(_config);
            player  = _engine.ObterJogador();

            mao1  = $"{player.Mao[0].Simbolo.ToString().ToLower()}{player.Mao[0].Nipe}";
            mao2  = $"{player.Mao[1].Simbolo.ToString().ToLower()}{player.Mao[1].Nipe}";
            mao3  = $"{player.Mao[2].Simbolo.ToString().ToLower()}{player.Mao[2].Nipe}";
            mao4  = $"{player.Mao[3].Simbolo.ToString().ToLower()}{player.Mao[3].Nipe}";
            mao5  = $"{player.Mao[4].Simbolo.ToString().ToLower()}{player.Mao[4].Nipe}";
            mao6  = $"{player.Mao[5].Simbolo.ToString().ToLower()}{player.Mao[5].Nipe}";
            mao7  = $"{player.Mao[6].Simbolo.ToString().ToLower()}{player.Mao[6].Nipe}";
            mao8  = $"{player.Mao[7].Simbolo.ToString().ToLower()}{player.Mao[7].Nipe}";
            mao9  = $"{player.Mao[8].Simbolo.ToString().ToLower()}{player.Mao[8].Nipe}";
            mao10 = $"{player.Mao[9].Simbolo.ToString().ToLower()}{player.Mao[9].Nipe}";
            mao11 = $"{player.Mao[10].Simbolo.ToString().ToLower()}{player.Mao[10].Nipe}";

            _cartas = $"{mao1} - {mao2} - {mao3} - {mao4} - {mao5} - {mao6} - {mao7} - {mao8} - {mao9} - {mao10} - {mao11} ";

            //ThicknessAnimation animacao = new ThicknessAnimation();
            //animacao.From = new System.Windows.Thickness(0, 0, 0, 0);
            //animacao.To   = new System.Windows.Thickness(0, -50, 0, 0); ;

        }

        public ICommand SelectCardCommand
        {
            get
            {
                if (_selectCardCommand == null)
                {
                    _selectCardCommand = new SelectCardCommand();
                    //((SelectCardCommand)_selectImageCommand);
                }

                return _selectCardCommand;
            }
            set
            {
                _selectCardCommand = value;
            }
        }

        public string Detalhes { get { return $"Mexe Mexe - {player.Nome}"; } set { Detalhes = value; NotifyPropertyChange(nameof(Detalhes)); } }

        public Thickness pocicaoUm { get { return new Thickness(10, 0, 0, 0); } set { pocicaoUm = value; NotifyPropertyChange(nameof(pocicaoUm)); } }

        public string Cartas { get { return _cartas; } set { _cartas = value; } }

        public string QuantidadeDeCartasPataCompra { get { return $"{_engine.QuantidadeDeCartas} cartas para compra"; } set { QuantidadeDeCartasPataCompra = value; NotifyPropertyChange(nameof(QuantidadeDeCartasPataCompra)); } }

        public string QuantidadeDeJogadores { get { return $"{_engine.QuantidadeDeJogadores} jogadores na mesa"; } set { QuantidadeDeJogadores = value; } }

        public string carta01
        {
            get{return $"../img/{mao1}.png";}
            set{carta01 = value;NotifyPropertyChange(nameof(carta01));}
        }

        public string carta02
        {
            get { return $"../img/{mao2}.png"; }
            set { carta02 = value; NotifyPropertyChange(nameof(carta02)); }
        }

        public string carta03
        {
            get { return $"../img/{mao3}.png"; }
            set { carta03 = value; NotifyPropertyChange(nameof(carta03)); }
        }

        public string carta04
        {
            get { return $"../img/{mao4}.png"; }
            set { carta04 = value; NotifyPropertyChange(nameof(carta04)); }
        }

        public string carta05
        {
            get { return $"../img/{mao5}.png"; }
            set { carta05 = value; NotifyPropertyChange(nameof(carta05)); }
        }

        public string carta06
        {
            get { return $"../img/{mao6}.png"; }
            set { carta06 = value; NotifyPropertyChange(nameof(carta06)); }
        }

        public string carta07
        {
            get { return $"../img/{mao7}.png"; }
            set { carta07 = value; NotifyPropertyChange(nameof(carta07)); }
        }

        public string carta08
        {
            get { return $"../img/{mao8}.png"; }
            set { carta08 = value; NotifyPropertyChange(nameof(carta08)); }
        }

        public string carta09
        {
            get { return $"../img/{mao9}.png"; }
            set { carta09 = value; NotifyPropertyChange(nameof(carta09)); }
        }

        public string carta10
        {
            get { return $"../img/{mao10}.png"; }
            set { carta10 = value; NotifyPropertyChange(nameof(carta10)); }
        }

        public string carta11
        {
            get { return $"../img/{mao11}.png"; }
            set { carta11 = value; NotifyPropertyChange(nameof(carta11)); }
        }

    }
}
