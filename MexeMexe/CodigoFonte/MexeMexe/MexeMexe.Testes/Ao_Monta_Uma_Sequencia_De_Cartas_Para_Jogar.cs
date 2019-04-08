using MexeMexe.Apresentacao.Wpf.ViewModel;
using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;
using System.Collections.Generic;
using Xunit;

namespace MexeMexe.Testes
{
    public class Ao_Monta_Uma_Sequencia_De_Cartas_Para_Jogar
    {
        private GameViewModel _gameViewModel;
        private Engine _engine;

        public Ao_Monta_Uma_Sequencia_De_Cartas_Para_Jogar()
        {
            Configuracao config = new Configuracao("Marquinhos", 2);
            _engine = new Engine(config);
        }

        [Fact]
        public void Tres_Cartas_De_Simbolo_Iguais_Deve_Retornar_True()
        {
            List<Carta> cartasSeparadasParaJogar = new List<Carta>
            {
                new Carta(NipeEnum.Copas, SimboloEnum.Dois,"01"),
                new Carta(NipeEnum.Espada, SimboloEnum.Dois,"02"),
                new Carta(NipeEnum.Ouro, SimboloEnum.Dois,"03"),
            };

            bool podeSeguir = _engine.VerificarSePodeAdicionarCarta(cartasSeparadasParaJogar);

            Assert.True(podeSeguir);

        }

        [Fact]
        public void Quatro_Cartas_De_Simbolo_Iguais_Deve_Retornar_True()
        {
            List<Carta> cartasSeparadasParaJogar = new List<Carta>
            {
                new Carta(NipeEnum.Copas, SimboloEnum.Dois,"01"),
                new Carta(NipeEnum.Espada, SimboloEnum.Dois,"02"),
                new Carta(NipeEnum.Ouro, SimboloEnum.Dois,"03"),
                new Carta(NipeEnum.Paus, SimboloEnum.Dois,"04"),
            };

            bool podeSeguir = _engine.VerificarSePodeAdicionarCarta(cartasSeparadasParaJogar);

            Assert.True(podeSeguir);

        }

        [Fact]
        public void Duas_Cartas_De_Simbolo_Igual_E_Uma_Diferente_Deve_Retornar_False()
        {
            List<Carta> cartasSeparadasParaJogar = new List<Carta>
            {
                new Carta(NipeEnum.Copas, SimboloEnum.Tres,"01"),
                new Carta(NipeEnum.Espada, SimboloEnum.Dois,"02"),
                new Carta(NipeEnum.Ouro, SimboloEnum.Dois,"03"),
            };

            bool podeSeguir = _engine.VerificarSePodeAdicionarCarta(cartasSeparadasParaJogar);

            Assert.False(podeSeguir);

        }

        [Fact]
        public void Tres_Cartas_De_Simbolo_Igual_E_Uma_Diferente_Deve_Retornar_False()
        {
            List<Carta> cartasSeparadasParaJogar = new List<Carta>
            {
                new Carta(NipeEnum.Copas, SimboloEnum.Seis,"01"),
                new Carta(NipeEnum.Espada, SimboloEnum.Dois,"02"),
                new Carta(NipeEnum.Ouro, SimboloEnum.Dois,"03"),
                new Carta(NipeEnum.Paus, SimboloEnum.Dois,"04"),
            };

            bool podeSeguir = _engine.VerificarSePodeAdicionarCarta(cartasSeparadasParaJogar);

            Assert.False(podeSeguir);

        }


        [Fact]
        public void Tres_Cartas_De_Nipe_Iguais_E_EM_Sequencia_Deve_Retornar_True()
        {
            List<Carta> cartasSeparadasParaJogar = new List<Carta>
            {
                new Carta(NipeEnum.Copas, SimboloEnum.Dois,"01"),
                new Carta(NipeEnum.Copas, SimboloEnum.Quatro,"02"),
                new Carta(NipeEnum.Copas, SimboloEnum.Tres,"03"),
            };

            bool podeSeguir = _engine.VerificarSePodeAdicionarCarta(cartasSeparadasParaJogar);

            Assert.True(podeSeguir);

        }
    }
}
