namespace MexeMexe.Dominio.Modelo
{
    public class Carta
    {
        public Carta(NipeEnum nipe, SimboloEnum simbolo, string id)
        {
            Nipe    = nipe;
            Simbolo = simbolo;
            Id      = id;
        }

        public NipeEnum Nipe { get; set; }

        public SimboloEnum Simbolo { get; set; }

        public string Id { get; set; }

        public string Nome { get { return $"{Simbolo} de {Nipe}"; } }
    }
}
