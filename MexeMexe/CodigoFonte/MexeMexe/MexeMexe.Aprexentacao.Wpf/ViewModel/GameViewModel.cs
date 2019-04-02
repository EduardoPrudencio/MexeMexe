using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;

namespace MexeMexe.Aprexentacao.Wpf.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        Configuracao _config;
        Engine       _engine ;
        Jogador player;

        string nomeDaCarta = string.Empty;

        public GameViewModel()
        {
            _config = new Configuracao("Marquinhos", 2);
            _engine = new Engine(_config);
            player = _engine.ObterJogador();

            nomeDaCarta = $"{player.Mao[0].Simbolo.ToString().ToLower()}{player.Mao[0].Nipe}";

            
        }

        public string textoTeste {
            get
            {
                return $"../img/{nomeDaCarta}.png";
            }
            set
            {
                textoTeste = value;NotifyPropertyChange(nameof(textoTeste));
            }
        }
        
    }
}
