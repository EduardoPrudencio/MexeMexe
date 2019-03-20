using MexeMexe.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MexeMexe.Implementacao.Engine
{
    public class Engine
    {
        List<Carta> Baralho;
        List<Jogador> jogadores;

        public Engine()
        {
            jogadores = new List<Jogador>();
            IniciarBaralho();
        }

        public int QuantidadeDeJogadores { get { return jogadores.Count(); } }

        private void IniciarBaralho()
        {
            var Nipes    = (NipeEnum[]) Enum.GetValues(typeof(NipeEnum));
            var simbolos = (SimboloEnum[])Enum.GetValues(typeof(SimboloEnum));

            Baralho = new List<Carta>();

            foreach (var nipe in Nipes)
            {
                foreach (var simbolo in simbolos)
                    Baralho.Add(new Carta(nipe, simbolo));
            }

            Baralho = Embaralhar(Baralho);
        }

        private List<Carta> Embaralhar(List<Carta> baralho)
        {
            List<Carta> baralhoEmbaralhado = new List<Carta>();

            int quantidadesDeCartasParaEmbaralhar = 52;
            Random random = new Random();

            while (baralho.Count > 1)
            {
                int posicaoDaCarta = random.Next(1, quantidadesDeCartasParaEmbaralhar);
                baralhoEmbaralhado.Add(baralho[posicaoDaCarta]);

                baralho = baralho.Where(x => !baralhoEmbaralhado.Contains(x)).ToList();

                quantidadesDeCartasParaEmbaralhar--;
            }

            baralhoEmbaralhado.Add(baralho[0]);
            baralho = null;


            return baralhoEmbaralhado;
        }

        private List<Carta> DarCartas()
        {
            List<Carta> cartasEntregues = new List<Carta>();

            cartasEntregues = Baralho.Take(11).ToList();

            OrdenarCartas(cartasEntregues);

            Baralho = Baralho.Where(x => !cartasEntregues.Contains(x)).ToList();

            return cartasEntregues;
        }

        private void OrdenarCartas(List<Carta> cartas)
        {
            IEnumerable<IGrouping<NipeEnum, Carta>> agrupadasPorNaipe = cartas.GroupBy(x => x.Nipe);

            foreach (var item in agrupadasPorNaipe)
            {
                var cartasOrdenadas = item.OrderBy(x => (int)x.Nipe).ToList();
            }

        }

        public void CriarJogadores(int quantidadeDeJogadores)
        {
            int cont = 1;

            while (cont <= quantidadeDeJogadores)
            {
                string guid = Guid.NewGuid().ToString().Replace("-","");

                Jogador jogador = new Jogador($"Jogador {cont}", guid);
                jogador.ReceberCartas(DarCartas());
                jogadores.Add(jogador);

                cont++;
            }
        }
    }
}
