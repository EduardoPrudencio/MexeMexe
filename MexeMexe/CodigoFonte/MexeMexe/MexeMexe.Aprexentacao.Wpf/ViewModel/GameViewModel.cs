using MexeMexe.Apresentacao.Wpf.Comandos;
using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MexeMexe.Apresentacao.Wpf.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        Configuracao _config;
        Engine _engine;
        Jogador player;
        string _quantidadeDeCartasPataCompra;
        private Image _imagemDeExemplo;
        StackPanel _stackCompraCartas;
        List<Image> _cartas;
        List<Carta> _cartasParaJogar;

        private ICommand _selectCardCommand;
        private ICommand _pedirCartaCommand;
        private ICommand _jogarCartasCommand;

        public event EventHandler MudouAMaoDoJogador;
        public event EventHandler PodeJogarCartasSelecionadas;
        public event EventHandler NaoPodeJogarCartasSelecionadas;
        public event EventHandler HouveDescarte;

        public GameViewModel()
        {
            IniciarDados();
        }

        public GameViewModel(List<Carta> cartasParaJogar)
        {
            IniciarDados();
            _cartasParaJogar.AddRange(cartasParaJogar);
        }

        public void NotificarMudacaoDaMaoDoJogador()
        {
           MudouAMaoDoJogador(this, EventArgs.Empty);
        }

        public void NotificarQueAsCartasPodemSerJogadas()
        {
            PodeJogarCartasSelecionadas(this, EventArgs.Empty);
        }

        public void NotificarQueAsCartasNaoPodemSerJogadas()
        {
            NaoPodeJogarCartasSelecionadas(this, EventArgs.Empty);
        }

        public void NotifcarDescarte()
        {
            HouveDescarte(this, EventArgs.Empty);
        }

        private List<Image> RetornarCartasDescartadas()
        {
            List<Image> cartas = new List<Image>();

            foreach (var carta in _cartasParaJogar)
            {
                Image img = ObterImagem($"{carta.Simbolo.ToString().ToLower()}{carta.Nipe}.png");
                img.Width = 90;
                cartas.Add(img);
            }

            return cartas;
        }

        private Image ObterImagem(string nomeDaImagem)
        {
            string pathImages = Directory.GetCurrentDirectory();

            pathImages = pathImages.Replace("bin", "@");
            pathImages = pathImages.Split('@')[0];

            Image img = new Image();

            string pathImage = $"{pathImages}img\\{nomeDaImagem}";

            Stream stream                = new FileStream(pathImage, FileMode.Open, FileAccess.Read);
            PngBitmapDecoder iconDecoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            ImageSource iconSource       = iconDecoder.Frames[0];
            img.Source                   = iconSource;
            return img;
        }

        private void GameViewModel_OnPedirCartas(object sender, System.EventArgs e)
        {
            if (_engine.QuantidadeDeCartas > 0)
            {
                Carta carta = _engine.PedirCarta();
                _quantidadeDeCartasPataCompra = _engine.QuantidadeDeCartas.ToString();
                player.Mao.Add(carta);
                _cartasParaJogar = new List<Carta>();
                PrepararImagemDoBaralhoDoJogador();
                NotificarMudacaoDaMaoDoJogador();
                NotifyPropertyChange(nameof(QuantidadeDeCartasPataCompra));
            }
            else
                ShowMessage("Todas as cartas já foram compradas.");
        }

        private void PrepararImagemDoBaralhoDoJogador()
        {
            _cartas = new List<Image>();
            int contadorDeCartas = 1;

            foreach (var carta in player.Mao)
            {
                Image novaCarta = ObterImagemDaCarta(carta, (contadorDeCartas < 10) ? $"0{contadorDeCartas.ToString()}" : contadorDeCartas.ToString());

                _cartas.Add(novaCarta);

                contadorDeCartas++;
            }
        }

        public List<Image> CartasParaJogar { get {  return RetornarCartasDescartadas(); } }

        private Image ObterImagemDaCarta(Carta carta, string commandParameterName)
        {
            Image novaCarta               = ObterImagem($"{carta.Simbolo.ToString().ToLower()}{carta.Nipe}.png");
            novaCarta.Width               = 90;
            string nomeDoCommandParameter = commandParameterName;
            novaCarta.Name                = $"carta{nomeDoCommandParameter}_{carta.Simbolo.ToString().ToLower()}_{carta.Nipe}";
            novaCarta.Margin              = new Thickness(10, 0, 0, 0);

            MouseGesture mouseGesture = new MouseGesture(MouseAction.LeftClick, ModifierKeys.None);
            MouseBinding mouseBinding = new MouseBinding(SelectCardCommand, mouseGesture);

            mouseBinding.CommandParameter = novaCarta;

            novaCarta.InputBindings.Add(mouseBinding);

            return novaCarta;
        }

        private void PrepararImagemDeCompraDeCartas()
        {
            Image img = ObterImagem("cartasCompra.png");
            img.Width = 130;
            _imagemDeExemplo = img;

            MouseGesture cmdMouseGesture = new MouseGesture(MouseAction.LeftClick, ModifierKeys.None);
            MouseBinding cmdMouseBinding = new MouseBinding(PedirCartaCommand, cmdMouseGesture);

            img.InputBindings.Add(cmdMouseBinding);

            _stackCompraCartas.Children.Add(img);
        }

        private void IniciarDados()
        {
            _config            = new Configuracao("Jogador - 1", 9);
            _engine            = new Engine(_config);
            player             = _engine.ObterJogador();
            _stackCompraCartas = new StackPanel();
            _cartasParaJogar   = new List<Carta>();

            _quantidadeDeCartasPataCompra = _engine.QuantidadeDeCartas.ToString();

            PrepararImagemDeCompraDeCartas();
            PrepararImagemDoBaralhoDoJogador();
        }

        public bool ValidarCartasParaJogar()
        {
            bool podeSeguir = _engine.VerificarSePodeAdicionarCarta(_cartasParaJogar);

            if (_cartasParaJogar.Count() >= 3 && podeSeguir)
                NotificarQueAsCartasPodemSerJogadas();
            else
                NotificarQueAsCartasNaoPodemSerJogadas();

            return podeSeguir;
        }

        public void DescratarCartas()
        {
            foreach (var carta in _cartasParaJogar)
                player.Mao.Remove(carta);
            
            NotifcarDescarte();
            PrepararImagemDoBaralhoDoJogador();
            NotificarQueAsCartasNaoPodemSerJogadas();
            NotificarMudacaoDaMaoDoJogador();
            //_cartasParaJogar = new List<Carta>();
        }

        public void AdcionarCartaParaSerJogada(string nomeCarta)
        {
            string[] pedacosDoNome = nomeCarta.Split('_');

            string simbolo = pedacosDoNome[1].ToLower();
            string naipe   = pedacosDoNome[2].ToLower();

            Carta c = player.Mao.FirstOrDefault(x => x.Simbolo.ToString().ToLower().Equals(simbolo) && x.Nipe.ToString().ToLower().Equals(naipe));

            if(c != null)
                _cartasParaJogar.Add(c);

        }

        public void RemoverCartaParaSerJogada(string nomeCarta)
        {
            string[] pedacosDoNome = nomeCarta.Split('_');

            string simbolo = pedacosDoNome[1].ToLower();
            string naipe = pedacosDoNome[2].ToLower();

            Carta c = player.Mao.FirstOrDefault(x => x.Simbolo.ToString().ToLower().Equals(simbolo) && x.Nipe.ToString().ToLower().Equals(naipe));

            _cartasParaJogar.Remove(c);

        }


        public ICommand SelectCardCommand
        {
            get
            {
                if (_selectCardCommand == null)
                {
                    _selectCardCommand = new SelectCardCommand(this);
                }

                return _selectCardCommand;
            }
            set
            {
                _selectCardCommand = value;
            }
        }

        public ICommand PedirCartaCommand
        {
            get
            {
                if (_pedirCartaCommand == null)
                {
                    _pedirCartaCommand = new PedirCartaCommand();

                    ((PedirCartaCommand)_pedirCartaCommand).OnPedirCartas += GameViewModel_OnPedirCartas;
                }

                return _pedirCartaCommand;
            }
            set
            {
                _pedirCartaCommand = value;
            }
        }

        public ICommand JogarCartasCommand
        {
            get
            {
                if (_jogarCartasCommand == null)
                {
                    _jogarCartasCommand = new JogarCartasCommand(this);
                }

                return _jogarCartasCommand;
            }
            set
            {
                _pedirCartaCommand = value;
            }
        }



        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        public StackPanel StackCompraCartas { get { return _stackCompraCartas; } }

        public List<Image> Cartas { get { return _cartas; } set { _cartas = value; } }

        public Image ImagemDeExemplo { get { return _imagemDeExemplo; } set { _imagemDeExemplo = value; NotifyPropertyChange(nameof(_imagemDeExemplo)); } }

        public string Detalhes { get { return $"Mexe Mexe - {player.Nome}"; } set { Detalhes = value; NotifyPropertyChange(nameof(Detalhes)); } }

        public string QuantidadeDeCartasPataCompra
        {
            get { return $"{_quantidadeDeCartasPataCompra} cartas para compra"; }
            set
            {
                _quantidadeDeCartasPataCompra = value;
                NotifyPropertyChange(nameof(QuantidadeDeCartasPataCompra));
            }
        }

        public string QuantidadeDeJogadores { get { return $"{_engine.QuantidadeDeJogadores} jogadores na mesa"; } set { QuantidadeDeJogadores = value; } }
       
    }
}
