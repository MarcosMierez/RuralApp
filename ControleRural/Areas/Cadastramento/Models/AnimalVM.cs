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
        public string NomeAnimal { get; set; }
        [Required]
        public string NumeroBrinco { get; set; }

        public string Sexo { get; set; }

        public string Raca { get; set; }

        public string Categoria { get; set; }

        public string Aptidao { get; set; }

        public string SisBov { get; set; }

        public string SisBovPai { get; set; }

        public string SisBovMae { get; set; }

        public DateTime DataNascimento { get; set; }

        public int NirfNascimento { get; set; }

        public int NirfAtual { get; set; }
        public int PropriedadeId { get; set; }

        public string IdUsuario { get; set; }
        public List<string> Vacinas { get; set; }
        public string PhotoPath { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public DateTime Aquisicao { get; set; }
        public string NomePropriedade { get; set; }
    }
}