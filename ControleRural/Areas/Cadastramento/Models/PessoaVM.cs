using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ControleRural.Areas.Cadastramento.Models
{
    public class PessoaVM
    {
        public string Id { get; set; }
        public string Apelido { get; set; }
        public string PessoaJf { get; set; }
        public string Cnpj { get; set; }
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",ErrorMessage = "O campo cpf deve ter a seguinte formatacao 000.000.000-00")]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Display(Name = "IE")]
        public string InscEstadual { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Fax { get; set; }
        [Required]
        public string Email { get; set; }
        public string IdUsuario { get; set; }

    }
}