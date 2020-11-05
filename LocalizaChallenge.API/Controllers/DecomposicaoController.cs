using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalizaChallenge.Domain.DTO;
using LocalizaChallenge.Domain.Interfaces;
using LocalizaChallenge.Domain.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocalizaChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecomposicaoController : ControllerBase
    {

        private readonly ILogger<DecomposicaoController> _logger;
        private readonly IDecomposicaoService _decomposicaoService;

        public DecomposicaoController(ILogger<DecomposicaoController> logger, IDecomposicaoService decomposicaoService)
        {
            _logger = logger;
            _decomposicaoService = decomposicaoService;
        }
        /// <summary>
        /// Obter divisores primos de um numero inteiro maior que 0 e menor que 9999999
        /// </summary>
        /// <param name="numeroNaturalDTO"></param>
        /// <returns></returns>
        [HttpPost("ObterDivisoresPrimos")]
        public ActionResult<object> CalcularDivisoresPrimos(NumeroNaturalDTO numeroNaturalDTO)
        {
            var numeroNaturalMapper = new NumeroNaturalMapper();
            var response =
                _decomposicaoService.DecomporNumeroEmFatoresPrimos(
                    numeroNaturalMapper.DTOToNumeroNatural(numeroNaturalDTO));

            if (response.Retorno == null)
            {
                return StatusCode(
                    (int)response.StatusCode,
                    new
                    {
                        mensagem = response.Message
                    });
            }

            return StatusCode((int)response.StatusCode, numeroNaturalMapper.NumeroNaturalToDTO(response.Retorno));
        }

        /// <summary>
        /// Obter divisores de um numero inteiro maior que 0 e menor que 9999999
        /// </summary>
        /// <param name="numeroNaturalDTO"></param>
        /// <returns></returns>
        [HttpPost("ObterDivisores")]
        public ActionResult<object> CalcularDivisores(NumeroNaturalDTO numeroNaturalDTO)
        {
            var numeroNaturalMapper = new NumeroNaturalMapper();
            var response =
                _decomposicaoService.DecomporNumeroEmDivisores(
                    numeroNaturalMapper.DTOToNumeroNatural(numeroNaturalDTO));

            if (response.Retorno == null)
            {
                return StatusCode(
                    (int)response.StatusCode,
                    new
                    {
                        mensagem = response.Message
                    });
            }

            return StatusCode((int)response.StatusCode, numeroNaturalMapper.NumeroNaturalToDTO(response.Retorno));
        }
    }
}
