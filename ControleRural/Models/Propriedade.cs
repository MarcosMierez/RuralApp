using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ControleRural.Models
{
    public class Propriedade
    {
        public int Id { get; set; }
        public string NomePropriedade { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Cep { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        public string Responsavel { get; set; }
        public DateTime Aquisicao { get; set; }
    }
}