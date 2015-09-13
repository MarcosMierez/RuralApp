using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ControleRural.Models;

namespace ControleRural.Areas.Cadastramento.Models
{
    public class AnimalVM
    {
        public AnimalVM()
        {
            Vacinas=new List<string>();
        }
        [Required]

        public string NomeAnimal { get; set; }
        [Required]
        public string NumeroBrinco { get; set; }
        [Required]
        public string Sexo { get; set; }
        [Required]

        public string Raca { get; set; }
        [Required]

        public string Categoria { get; set; }
        [Required]

        public string Aptidao { get; set; }
        [Required]

        public string SisBov { get; set; }
        [Required]

        public string SisBovPai { get; set; }
        [Required]

        public string SisBovMae { get; set; }
        [Required]

        public DateTime DataNascimento { get; set; }
        [Required]

        public int NirfNascimento { get; set; }
        [Required]

        public int NirfAtual { get; set; }

        public string IdUsuario { get; set; }
        public List<string> Vacinas { get; set; }
        public string PhotoPath { get; set; }
        public HttpPostedFileBase Photo { get; set; }
    }
}