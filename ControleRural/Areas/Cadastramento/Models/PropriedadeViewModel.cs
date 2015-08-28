using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleRural.Areas.Cadastramento.Models
{
    public class PropriedadeViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Propriedade")]
        public string NomePropriedade { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]

        public string Numero { get; set; }
        [Required]

        public string Complemento { get; set; }
        [Required]

        public string Bairro { get; set; }
        [Required]

        public string Cidade { get; set; }
        [Required]

        public int Cep { get; set; }
        [Required]

        public string Telefone { get; set; }
        [Required]

        public string Fax { get; set; }
        [Required]

        public string Responsavel { get; set; }
        [Required]
        public DateTime Aquisicao { get; set; }

    }
}