using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocalizaChallenge.Domain.DTO
{
    public class NumeroNaturalDTO
    {
        [Required(ErrorMessage = "O numero é obrigatorio.")]
        [Range(1, 9999999, ErrorMessage = "Por favor insira um numero maior que 0 e menor que 9999999.")]
        public int? Numero { get; set; }
        public List<int> DivisoresPrimos { get; set; }
        public List<long> Divisores { get; set; }
    }
}