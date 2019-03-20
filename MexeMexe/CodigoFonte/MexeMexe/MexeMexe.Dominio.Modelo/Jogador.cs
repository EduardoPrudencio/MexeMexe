using System.Collections.Generic;

namespace MexeMexe.Dominio.Modelo
{
    public class Jogador
    {
        private List<Carta> Mao;
        private string _nome;
        private string _id;

        public Jogador(string nome, string id)
        {
            _id   = id;
            _nome = nome;
            Mao   = new List<Carta>();
        }

        public string Nome { get { return _nome; } }

        public string Id { get { return _id; } }

        public void ReceberCartas(List<Carta> cartas)
        {
            this.Mao = cartas;
        }
    }
}
