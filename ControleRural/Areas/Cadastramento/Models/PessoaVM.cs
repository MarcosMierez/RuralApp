using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleRural.Areas.Cadastramento.Models
{
    public class PessoaVM
    {
        [Required]
        public string Id { get; set; }
        public string Apelido { get; set; }
        public bool PessoaJf { get; set; }
        public int Cnpj { get; set; }
        public int Cpf { get; set; }
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
    }
}