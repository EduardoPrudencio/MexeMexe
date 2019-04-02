using System;
using System.Collections.Generic;
using System.Text;

namespace MexeMexe.Infraestrutura.Conteudo
{
    public class Configuracao
    {
        public Configuracao(string nomeDoJogador, int qunatidadeDeJogadores)
        {
            NomeDoJogador = nomeDoJogador;
            QunatidadeDeJogadores = qunatidadeDeJogadores;
        }

        public string NomeDoJogador { get; set; }

        public int QunatidadeDeJogadores { get; set; }

    }
}
