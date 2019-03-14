using System;
using System.Collections.Generic;

namespace MexeMexe.Dominio.Modelo
{
    public class Jogador
    {
        private List<Carta> Mao;
        private string _nome;

        public Jogador(string nome)
        {
            _nome = nome;
            Mao   = new List<Carta>();
        }

        public string Nome { get { return _nome; } }

        public void ReceberCartas(List<Carta> cartas)
        {
            this.Mao = cartas;
        }
    }
}
