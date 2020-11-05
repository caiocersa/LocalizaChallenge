using System.Collections.Generic;
using LocalizaChallenge.Domain.Entities;

namespace LocalizaChallenge.Domain.Interfaces
{
    public interface IDecomposicaoService : IBaseService
    {
        IServiceResponse<NumeroNatural> DecomporNumeroEmFatoresPrimos(NumeroNatural numeroNatural);
        IServiceResponse<NumeroNatural> DecomporNumeroEmDivisores(NumeroNatural numeroNatural);

    }
}