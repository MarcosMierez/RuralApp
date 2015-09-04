using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleRural.Areas.Cadastramento.Models
{
    public class VacinaVM
    {
        public int Id { get; set; }
        [Required]
        public int NumeroLote { get; set; }
        [Required]
        public DateTime DataCompra { get; set; }
        [Required]
        public string TipoVacina { get; set; }
        [Required]
        public DateTime Vencimento { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public string IdUsuario { get; set; }

    }
}