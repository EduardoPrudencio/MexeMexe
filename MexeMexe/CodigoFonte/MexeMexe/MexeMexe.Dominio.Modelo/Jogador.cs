using System.Collections.Generic;

namespace MexeMexe.Dominio.Modelo
{
    public class Jogador
    {
        private List<Carta> _mao;
        private string _nome;
        private string _id;

        public Jogador(string nome, string id)
        {
            _id   = id;
            _nome = nome;
            _mao   = new List<Carta>();
        }

        public string Nome { get { return _nome; } set { _nome = value; } }

        public string Id { get { return _id; } }

        public List<Carta> Mao { get { return _mao; } }

        public void ReceberCartas(List<Carta> cartas)
        {
            this._mao = cartas;
        }
    }
}
