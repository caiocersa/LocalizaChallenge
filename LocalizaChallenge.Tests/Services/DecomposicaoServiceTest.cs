using LocalizaChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using LocalizaChallenge.Domain.Entities;
using LocalizaChallenge.Service.Service;
using Xunit;

namespace LocalizaChallenge.Tests.Services
{
    public class DecomposicaoServiceTest
    {
        private readonly IDecomposicaoService _decomposicaoService = new DecomposicaoService();

        [Theory]
        [InlineData(9)]
        [InlineData(99)]
        [InlineData(999)]
        [InlineData(9999)]
        [InlineData(99999)]
        [InlineData(999999)]
        [InlineData(9999999)]
        public void DecomposicaoService_ObterDivisoresPrimos_RetornaLista_OK(int numero)
        {
            //Arrange
            var numeroNatural = new NumeroNatural(numero);

            //Act
            var result = _decomposicaoService.DecomporNumeroEmFatoresPrimos(numeroNatural);
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            

        }


        [Theory]
        [InlineData(0)]
        [InlineData(-999)]
        [InlineData(-999999)]
        [InlineData(-9999999)]
        public void DecomposicaoService_ObterDivisoresPrimos_ComNumeroMenorOuIgualAZero_Retorna_BadRequest(int numero)
        {
            //Arrange
            var numeroNatural = new NumeroNatural(numero);

            //Act
            var result = _decomposicaoService.DecomporNumeroEmFatoresPrimos(numeroNatural);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Theory]
        [InlineData(9)]
        [InlineData(99)]
        [InlineData(999)]
        [InlineData(9999)]
        [InlineData(99999)]
        [InlineData(999999)]
        [InlineData(9999999)]
        public void DecomposicaoService_ObterDivisores_RetornaLista_OK(int numero)
        {
            //Arrange
            var numeroNatural = new NumeroNatural(numero);

            //Act
            var result = _decomposicaoService.DecomporNumeroEmDivisores(numeroNatural);

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-999)]
        [InlineData(-999999)]
        [InlineData(-9999999)]
        public void DecomposicaoService_ObterDivisores_ComNumeroMenorOuIgualAZero_Retorna_BadRequest(int numero)
        {
            //Arrange
            var numeroNatural = new NumeroNatural(numero);

            //Act
            var result = _decomposicaoService.DecomporNumeroEmDivisores(numeroNatural);

            //Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
