using System;
using System.Collections.Generic;
using System.Text;

namespace MexeMexe.Dominio.Modelo
{
    public class Carta
    {
        public Carta(NipeEnum nipe, SimboloEnum simbolo)
        {
            Nipe    = nipe;
            Simbolo = simbolo;
        }

        public NipeEnum Nipe { get; set; }

        public SimboloEnum Simbolo { get; set; }

        public string Nome { get { return $"{Simbolo} de {Nipe}"; } }
    }
}
