﻿using MexeMexe.Dominio.Modelo;
using MexeMexe.Infraestrutura.Conteudo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MexeMexe.Implementacao.Engine
{
    public class Engine
    {
        List<Carta>   Baralho;
        List<Jogador> jogadores;
        Configuracao  _configuracao;

        public Engine(Configuracao configuracao)
        {
            jogadores     = new List<Jogador>();
            Baralho       = new List<Carta>();
            _configuracao = configuracao;

            CriarJogadores();
        }

        public int QuantidadeDeJogadores { get { return jogadores.Count(); } }
        public int QuantidadeDeCartas { get { return Baralho.Count; } }

        private void CriarJogadores()
        {
            ObterBaralhosNecessarios(_configuracao.QunatidadeDeJogadores);
            Baralho = Embaralhar(Baralho);
             
            int contJogadores = 1;

            while (contJogadores <= _configuracao.QunatidadeDeJogadores)
            {
                string guid = Guid.NewGuid().ToString().Replace("-", "");

                Jogador jogador = new Jogador($"Jogador {contJogadores}", guid);
                jogador.ReceberCartas(DarCartas());
                jogadores.Add(jogador);

                contJogadores++;
            }
        }

        public List<Carta> OrdenarCartas(List<Carta> cartas)
        {
            IEnumerable<IGrouping<NipeEnum, Carta>> agrupadasPorNaipe = cartas.GroupBy(x => x.Nipe);

            List<Carta> baralhoTemp = new List<Carta>();

            foreach (var item in agrupadasPorNaipe)
            {
                var cartasOrdenadas = item.OrderBy(x => (int)x.Simbolo).ToList();
                baralhoTemp.AddRange(cartasOrdenadas);
            }

            cartas = baralhoTemp;
            baralhoTemp = null;

            return cartas;
        }

        public Jogador ObterJogador()
        {
            Jogador jogadorConectado = jogadores[0];
            jogadorConectado.Nome    = _configuracao.NomeDoJogador;

            return jogadorConectado;
        }

        public Carta PedirCarta()
        {
            if (!Baralho.Any())
                return null;

            List<Carta> baralhoTemp = new List<Carta>();

            Carta cartaComprada = Baralho[0];

            if (Baralho.Count > 1)
            {
                baralhoTemp = Baralho.Where(x => x != Baralho[0]).ToList();
            }

            Baralho = baralhoTemp;
            baralhoTemp = null;

            return cartaComprada;
        }


        private List<Carta> CriarBaralho()
        {
            var Nipes    = (NipeEnum[]) Enum.GetValues(typeof(NipeEnum));
            var simbolos = (SimboloEnum[])Enum.GetValues(typeof(SimboloEnum));

            List<Carta> baralho = new List<Carta>();

            foreach (var nipe in Nipes)
            {
                foreach (var simbolo in simbolos)
                {
                    string id = Guid.NewGuid().ToString();
                    baralho.Add(new Carta(nipe, simbolo, id));
                }
            }

            return baralho;
        }

        private List<Carta> Embaralhar(List<Carta> baralho)
        {
            List<Carta> baralhoEmbaralhado = new List<Carta>();

            int quantidadesDeCartasParaEmbaralhar = baralho.Count;
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

            cartasEntregues = OrdenarCartas(cartasEntregues);

            Baralho = Baralho.Where(x => !cartasEntregues.Contains(x)).ToList();

            return cartasEntregues;
        }

        private int DefinirQuantidadeDeBaralhos(int quantidadeDeJogadores)
        {
            int quantidadeDeBaralho = 2;

            if (quantidadeDeJogadores > 4)
                quantidadeDeBaralho = quantidadeDeJogadores / 4;

            return quantidadeDeBaralho;
        }

        private void ObterBaralhosNecessarios(int quantidadeDeJogadores)
        {
            int numeroDeBaralhos = DefinirQuantidadeDeBaralhos(quantidadeDeJogadores);
            int contBaralhos = 0;

            while (contBaralhos < numeroDeBaralhos)
            {
                Baralho.AddRange(CriarBaralho());
                contBaralhos++;
            }
        }
    }
}

