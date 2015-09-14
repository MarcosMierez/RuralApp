using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ControleRural.Models
{
    public class RegistroAnimal
    {
        public int ID { get; set; }
        [Required]
        public string IdAnimal { get; set; }
        public string UsuarioId { get; set; }
        [Required]
        public string Natureza { get; set; }
        [Required]
        public int Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Sexo { get; set; }
        public string Raca { get; set; }
        public string Aptidao { get; set; }

    }
}