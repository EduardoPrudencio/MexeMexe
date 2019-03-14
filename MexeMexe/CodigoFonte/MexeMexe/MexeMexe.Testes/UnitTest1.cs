using MexeMexe.Implementacao.Engine;
using System;
using Xunit;

namespace MexeMexe.Testes
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Engine _engine = new Engine();
            _engine.CriarJogadores(2);
        }
    }
}
