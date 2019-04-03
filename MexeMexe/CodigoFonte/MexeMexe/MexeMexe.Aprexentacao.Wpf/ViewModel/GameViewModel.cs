using MexeMexe.Aprexentacao.Wpf.Comandos;
using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MexeMexe.Aprexentacao.Wpf.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        Configuracao _config;
        Engine _engine;
        string _cartas = string.Empty;
        Jogador player;
        string _quantidadeDeCartasPataCompra;
        private Image _imagemDeExemplo;
        StackPanel _stackCompraCartas;

        private ICommand _selectCardCommand;
        private ICommand _pedirCartaCommand;

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
            _config            = new Configuracao("Jogador - 1", 9);
            _engine            = new Engine(_config);
            player             = _engine.ObterJogador();
            _stackCompraCartas = new StackPanel();

            mao1 = $"{player.Mao[0].Simbolo.ToString().ToLower()}{player.Mao[0].Nipe}";
            mao2 = $"{player.Mao[1].Simbolo.ToString().ToLower()}{player.Mao[1].Nipe}";
            mao3 = $"{player.Mao[2].Simbolo.ToString().ToLower()}{player.Mao[2].Nipe}";
            mao4 = $"{player.Mao[3].Simbolo.ToString().ToLower()}{player.Mao[3].Nipe}";
            mao5 = $"{player.Mao[4].Simbolo.ToString().ToLower()}{player.Mao[4].Nipe}";
            mao6 = $"{player.Mao[5].Simbolo.ToString().ToLower()}{player.Mao[5].Nipe}";
            mao7 = $"{player.Mao[6].Simbolo.ToString().ToLower()}{player.Mao[6].Nipe}";
            mao8 = $"{player.Mao[7].Simbolo.ToString().ToLower()}{player.Mao[7].Nipe}";
            mao9 = $"{player.Mao[8].Simbolo.ToString().ToLower()}{player.Mao[8].Nipe}";
            mao10 = $"{player.Mao[9].Simbolo.ToString().ToLower()}{player.Mao[9].Nipe}";
            mao11 = $"{player.Mao[10].Simbolo.ToString().ToLower()}{player.Mao[10].Nipe}";

            _cartas = $"{mao1} - {mao2} - {mao3} - {mao4} - {mao5} - {mao6} - {mao7} - {mao8} - {mao9} - {mao10} - {mao11} ";

            _quantidadeDeCartasPataCompra = _engine.QuantidadeDeCartas.ToString();

            //var pathImages = $"{Directory.GetCurrentDirectory()}\\img\\cartasCompra.png";
            Image img = ObterImagem("cartasCompra.png");
            img.Width = 130;
            _imagemDeExemplo = img;

            _stackCompraCartas.Children.Add(img);


            //MouseGesture mouseGesture = new MouseGesture(MouseAction.LeftClick);
            //DependencyProperty commProp = Rea RadMenuItem.CommandProperty;
            //DependencyProperty MouseUpCommandProperty =
            //DependencyProperty.RegisterAttached(
            //                  "MouseUpCommand", typeof(ICommand), typeof(MouseBehaviour), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseUpCommandChanged)));

            //if (!BindingOperations.IsDataBound(img, commProp))
            //{
            //    Binding binding = new Binding("PedirCartaCommand");
            //    BindingOperations.SetBinding(img, commProp, binding);
            //}

            //this is optional, i found easier to pass the direct ref of the parameter instead of another binding (it would be a binding to ElementName).
            //item.CommandParameter = headerlCell.Column;
            //menu.Items.Add(item);


            //img.SetBinding()

            //SetBinding(Buttom.CommandProperty, new Binding("SaveReservationCommand"));


        }

        public ICommand SelectCardCommand
        {
            get
            {
                if (_selectCardCommand == null)
                {
                    _selectCardCommand = new SelectCardCommand();
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

        private void GameViewModel_OnPedirCartas(object sender, System.EventArgs e)
        {
            if (_engine.QuantidadeDeCartas > 0)
            {
                Carta carta = _engine.PedirCarta();
                _quantidadeDeCartasPataCompra = _engine.QuantidadeDeCartas.ToString();
                NotifyPropertyChange(nameof(QuantidadeDeCartasPataCompra));
            }
            else
                ShowMessage("Todas as cartas já foram compradas.");
        }


        public StackPanel StackCompraCartas { get { return _stackCompraCartas; } }

        public Image ImagemDeExemplo { get { return _imagemDeExemplo; } set { _imagemDeExemplo = value; NotifyPropertyChange(nameof(_imagemDeExemplo)); } }

        public string Detalhes { get { return $"Mexe Mexe - {player.Nome}"; } set { Detalhes = value; NotifyPropertyChange(nameof(Detalhes)); } }

        public Thickness pocicaoUm { get { return new Thickness(10, 0, 0, 0); } set { pocicaoUm = value; NotifyPropertyChange(nameof(pocicaoUm)); } }

        public string Cartas { get { return _cartas; } set { _cartas = value; } }

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

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private Image ObterImagem(string nomeDaImagem)
        {
            Image img = new Image();
            FileStream stream            = new FileStream($"D:\\Git\\Projetos\\Pessoal\\MexeMexe\\MexeMexe\\CodigoFonte\\MexeMexe\\MexeMexe.Aprexentacao.Wpf\\img\\{nomeDaImagem}", FileMode.Open);
            PngBitmapDecoder iconDecoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            ImageSource iconSource       = iconDecoder.Frames[0];
            img.Source                   = iconSource;
            return img;
        }
    }
}
