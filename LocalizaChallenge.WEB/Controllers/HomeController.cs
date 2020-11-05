using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LocalizaChallenge.Domain.DTO;
using LocalizaChallenge.Domain.Interfaces;
using LocalizaChallenge.Domain.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocalizaChallenge.WEB.Models;

namespace LocalizaChallenge.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDecomposicaoService _decomposicaoService;

        public HomeController(ILogger<HomeController> logger, IDecomposicaoService decomposicaoService)
        {
            _logger = logger;
            _decomposicaoService = decomposicaoService;
        }

        public IActionResult CalcularDivisores()
        {
            return View();
        }

        public IActionResult CalcularDivisoresPrimos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult<object> ObterDivisoresPrimos(NumeroNaturalDTO numeroNaturalDTO)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var numeroNaturalMapper = new NumeroNaturalMapper();
            var response =
                _decomposicaoService.DecomporNumeroEmFatoresPrimos(
                    numeroNaturalMapper.DTOToNumeroNatural(numeroNaturalDTO));

            if (response.Retorno == null)
            {
                ViewBag.Information = response.Message;
                return View("CalcularDivisoresPrimos");
            }

            return View("CalcularDivisoresPrimos", numeroNaturalMapper.NumeroNaturalToDTO(response.Retorno));
        }

        [HttpPost]
        public ActionResult<object> ObterDivisores(NumeroNaturalDTO numeroNaturalDTO)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var numeroNaturalMapper = new NumeroNaturalMapper();
            var response =
                _decomposicaoService.DecomporNumeroEmDivisores(
                    numeroNaturalMapper.DTOToNumeroNatural(numeroNaturalDTO));

            if (response.Retorno == null)
            {
                ViewBag.Information = response.Message;
                return View("CalcularDivisoresPrimos");
            }

            return View("CalcularDivisores", numeroNaturalMapper.NumeroNaturalToDTO(response.Retorno));
        }
    }
}
