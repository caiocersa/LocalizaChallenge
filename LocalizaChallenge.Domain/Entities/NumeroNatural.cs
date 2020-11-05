using System.Collections.Generic;

namespace LocalizaChallenge.Domain.Entities
{
    public class NumeroNatural
    {
        public int Numero { get; set; }
        public List<int> DivisoresPrimos { get; set; }
        public List<long> Divisores { get; set; }

        public NumeroNatural(int numero)
        {
            Numero = numero;
            DivisoresPrimos = new List<int>();
            Divisores = new List<long>();
        }
    }
}