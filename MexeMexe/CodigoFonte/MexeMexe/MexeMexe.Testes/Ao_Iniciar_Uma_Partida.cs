using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;
using System.Collections.Generic;
using Xunit;

namespace MexeMexe.Testes
{
    public class Ao_Iniciar_Uma_Partida
    {
        Engine _engine;

        public Ao_Iniciar_Uma_Partida()
        {
            
        }

        [Fact]
        public void A_Quantidade_De_Jogadores_Criada_deve_Ser_A_Mesma_Definida()
        {
            Configuracao config = new Configuracao("Marquinhos", 2);
            Engine _engine = new Engine(config);
            Assert.True(_engine.QuantidadeDeJogadores == 2);
        }

        [Fact]
        public void A_Quantidade_De_Cartas_Deve_Ser_Igual_A_Cinco()
        {
            Configuracao config = new Configuracao("Marquinhos", 9);
            Engine _engine      = new Engine(config);
            Jogador jogador     = _engine.ObterJogador();

            Assert.True(_engine.QuantidadeDeCartas == 5);
        }


        [Fact]
        public void As_Cartas_Devem_Ser_Ordenadas()
        {
            Configuracao config = new Configuracao("Marquinhos", 9);
            Engine _engine      = new Engine(config);

            List<Carta> baralho = new List<Carta>
            {
                new Carta(NipeEnum.Ouro, SimboloEnum.Dez,"0001"),
                new Carta(NipeEnum.Ouro, SimboloEnum.Dois,"0002"),
                new Carta(NipeEnum.Ouro, SimboloEnum.As,"0003"),
                new Carta(NipeEnum.Ouro, SimboloEnum.Tres,"0004"),
            };

            baralho = _engine.OrdenarCartas(baralho);

            Assert.True(baralho[0].Simbolo == SimboloEnum.Dois);
            Assert.True(baralho[1].Simbolo == SimboloEnum.Tres);
            Assert.True(baralho[2].Simbolo == SimboloEnum.Dez);
            Assert.True(baralho[3].Simbolo == SimboloEnum.As);
        }
    }
}
