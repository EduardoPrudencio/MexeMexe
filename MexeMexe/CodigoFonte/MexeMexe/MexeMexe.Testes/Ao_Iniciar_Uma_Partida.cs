using MexeMexe.Implementacao.Engine;
using Xunit;

namespace MexeMexe.Testes
{
    public class Ao_Iniciar_Uma_Partida
    {
        [Fact]
        public void A_Quantidade_De_Jogadores_Criada_deve_Ser_A_Mesma_Definida()
        {
            Engine _engine = new Engine();
            _engine.CriarJogadores(2);

            Assert.True(_engine.QuantidadeDeJogadores == 2);
        }
    }
}
