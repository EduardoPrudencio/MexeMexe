﻿using MexeMexe.Aprexentacao.Wpf.Comandos;
using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MexeMexe.Aprexentacao.Wpf.ViewModel
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
            _config              = new Configuracao("Jogador - 1", 9);
            _engine              = new Engine(_config);
            player               = _engine.ObterJogador();
            _stackCompraCartas   = new StackPanel();

            _quantidadeDeCartasPataCompra = _engine.QuantidadeDeCartas.ToString();

            PrepararImagemDeCompraDeCartas();
            PrepararImagemDoBaralhoDoJogador();

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

        private void PrepararImagemDoBaralhoDoJogador()
        {
            _cartas = new List<Image>();
            int contadorDeCartas = 1;

            foreach (var carta in player.Mao)
            {
                Image novaCarta               = ObterImagem($"{carta.Simbolo.ToString().ToLower()}{carta.Nipe}.png");
                novaCarta.Width               = 90;
                string nomeDoCommandParameter = (contadorDeCartas < 10) ? $"0{contadorDeCartas.ToString()}" : contadorDeCartas.ToString();
                novaCarta.Name                = $"carta{nomeDoCommandParameter}";
                novaCarta.Margin              = new Thickness(10, 0, 0, 0);

                MouseGesture mouseGesture     = new MouseGesture(MouseAction.LeftClick, ModifierKeys.None);
                MouseBinding mouseBinding     = new MouseBinding(SelectCardCommand, mouseGesture);
                mouseBinding.CommandParameter = novaCarta;

                novaCarta.InputBindings.Add(mouseBinding);

                _cartas.Add(novaCarta);

                contadorDeCartas++;
            }
        }

        private void PrepararImagemDeCompraDeCartas()
        {
            Image img        = ObterImagem("cartasCompra.png");
            img.Width        = 130;
            _imagemDeExemplo = img;

            MouseGesture cmdMouseGesture = new MouseGesture(MouseAction.LeftClick, ModifierKeys.None);
            MouseBinding cmdMouseBinding = new MouseBinding(PedirCartaCommand, cmdMouseGesture);

            img.InputBindings.Add(cmdMouseBinding);

            _stackCompraCartas.Children.Add(img);
        }

        public StackPanel StackCompraCartas { get { return _stackCompraCartas; } }

        public List<Image> Cartas { get { return _cartas; } set { _cartas = value; } }

        public Image ImagemDeExemplo { get { return _imagemDeExemplo; } set { _imagemDeExemplo = value; NotifyPropertyChange(nameof(_imagemDeExemplo)); } }

        public string Detalhes { get { return $"Mexe Mexe - {player.Nome}"; } set { Detalhes = value; NotifyPropertyChange(nameof(Detalhes)); } }

        public Thickness pocicaoUm { get { return new Thickness(10, 0, 0, 0); } set { pocicaoUm = value; NotifyPropertyChange(nameof(pocicaoUm)); } }

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

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
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
    }
}
