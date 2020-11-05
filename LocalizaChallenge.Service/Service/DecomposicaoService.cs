using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using LocalizaChallenge.Domain.Entities;
using LocalizaChallenge.Domain.Interfaces;
using LocalizaChallenge.Service.Util;

namespace LocalizaChallenge.Service.Service
{
    public class DecomposicaoService : IDecomposicaoService
    {
        /// <summary>
        /// Serviço para decompor um numero em fatores primos
        /// </summary>
        /// <param name="numeroNatural"></param>
        /// <returns></returns>
        public IServiceResponse<NumeroNatural> DecomporNumeroEmFatoresPrimos(NumeroNatural numeroNatural)
        {
            int index = 0;
            long quociente = numeroNatural.Numero;
            List<int> listaFatoresPrimos = new List<int>();
            listaFatoresPrimos.Add(1);

            try
            {
                var listaNumeroPrimos = ObterNumerosPrimos(numeroNatural).ToList();

                while (quociente != 1)
                {
                    var divisor = listaNumeroPrimos[index];

                    if (quociente % divisor == 0)
                    {
                        quociente = quociente / divisor;
                        listaFatoresPrimos.Add(divisor);

                        index = 0;
                    }
                    else
                        index++;
                }

                numeroNatural.DivisoresPrimos = listaFatoresPrimos.Distinct().ToList();

                return new ServiceResponse<NumeroNatural>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Retorno = numeroNatural
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"DecomporNumeroEmFatoresPrimosEQuocientes => {ex.Message}");
                return new ServiceResponse<NumeroNatural>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Retorno = null
                };
            }
        }
        
        /// <summary>
        /// Serviço para decompor numero em seus divisores.
        /// </summary>
        /// <param name="numeroNatural"></param>
        /// <returns></returns>
        public IServiceResponse<NumeroNatural> DecomporNumeroEmDivisores(NumeroNatural numeroNatural)
        {
            try
            {
                for (long numero = numeroNatural.Numero; numero > 0; numero--)
                {
                    if (numeroNatural.Numero % numero == 0)
                        numeroNatural.Divisores.Add(numero);
                }

                return new ServiceResponse<NumeroNatural>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Retorno = numeroNatural
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"DecomporNumeroEmDivisores => {ex.Message}");
                return new ServiceResponse<NumeroNatural>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Retorno = null
                };
            }

        }

        private static ParallelQuery<int> ObterNumerosPrimos(NumeroNatural numeroNatural)
        {
            var numerosPrimos = from i in Enumerable.Range(2, (int)(numeroNatural.Numero - 1)).AsParallel()
                where Enumerable.Range(1, (int)Math.Sqrt(i)).All(j => j == 1 || i % j != 0)
                select i;
            return numerosPrimos;
        }

    }
}
