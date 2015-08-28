using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ControleRural.Models
{
    public class Animal
    {
        public string NomeAnimal { get; set; }
        public string NumeroBrinco { get; set; }
        public bool Sexo { get; set; }
        public string Raca { get; set; }
        public string Categoria { get; set; }
        public string  Aptidao { get; set; }
        public string SisBov { get; set; }
        public string SisBovPai { get; set; }
        public string SisBovMae { get; set; } 
        public DateTime DataNascimento { get; set; }
        public int NirfNascimento { get; set; }
        public int NirfAtual { get; set; }
    }
}