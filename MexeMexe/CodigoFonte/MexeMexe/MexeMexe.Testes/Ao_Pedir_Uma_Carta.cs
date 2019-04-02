using MexeMexe.Dominio.Modelo;
using MexeMexe.Implementacao.Engine;
using MexeMexe.Infraestrutura.Conteudo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MexeMexe.Testes
{
    public class Ao_Pedir_Uma_Carta
    {
        [Fact]
        public void A_Carta_Deve_Ser_Removida_Do_Baralho()
        {
            Configuracao config = new Configuracao("Marquinhos", 2);
            Engine _engine = new Engine(config);

            Carta cartaRecebida = _engine.PedirCarta();

            int quantidadeDeCartas = _engine.QuantidadeDeCartas;

            Assert.True(quantidadeDeCartas == 81);

        }
    }
}
