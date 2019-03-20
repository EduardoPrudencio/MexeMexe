using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using System.Collections.Generic;
using Xunit;

namespace MexeMexe.Testes
{
    public class Ao_Iniciar_Uma_Partida
    {
        Engine _engine;

        public Ao_Iniciar_Uma_Partida()
        {
            _engine = new Engine();
        }

        [Fact]
        public void A_Quantidade_De_Jogadores_Criada_deve_Ser_A_Mesma_Definida()
        {
            _engine.CriarJogadores(2);

            Assert.True(_engine.QuantidadeDeJogadores == 2);
        }

        [Fact]
        public void As_Cartas_Devem_Ser_Ordenadas()
        {
            List<Carta> baralho = new List<Carta>
            {
                new Carta(NipeEnum.Ouro, SimboloEnum.Dez),
                new Carta(NipeEnum.Ouro, SimboloEnum.Dois),
                new Carta(NipeEnum.Ouro, SimboloEnum.As),
                new Carta(NipeEnum.Ouro, SimboloEnum.Tres),
            };

            baralho = _engine.OrdenarCartas(baralho);

            Assert.True(baralho[0].Simbolo == SimboloEnum.Dois);
            Assert.True(baralho[1].Simbolo == SimboloEnum.Tres);
            Assert.True(baralho[2].Simbolo == SimboloEnum.Dez);
            Assert.True(baralho[3].Simbolo == SimboloEnum.As);
        }
    }
}
