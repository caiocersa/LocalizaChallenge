using System;
using LocalizaChallenge.Domain.DTO;
using LocalizaChallenge.Domain.Entities;

namespace LocalizaChallenge.Domain.Mapper
{
    public class NumeroNaturalMapper
    {
        public NumeroNatural DTOToNumeroNatural(NumeroNaturalDTO numeroNaturalDTO)
        {
            return new NumeroNatural(numeroNaturalDTO.Numero.Value);
        }

        public NumeroNaturalDTO NumeroNaturalToDTO(NumeroNatural numeroNatural)
        {
            return new NumeroNaturalDTO()
            {
                Numero = numeroNatural.Numero,
                DivisoresPrimos = numeroNatural.DivisoresPrimos,
                Divisores = numeroNatural.Divisores
            };
        }
    }
}