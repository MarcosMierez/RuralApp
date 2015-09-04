using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleRural.Models
{
    public class Pessoa
    {
        public string Id { get; set; }
        public string Apelido { get; set; }
        public string PessoaJf { get; set; }
        public int Cnpj { get; set; }
        public int  Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
       
        public string InscEstadual { get; set; }
        public string Telefone { get; set; }
        public string Fax  { get; set; }
        public string IdUsuario { get; set; }

        public string Email { get; set; }
    }
}