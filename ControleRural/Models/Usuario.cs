using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRural.Models
{
    public class Usuario
    {
        public Usuario()
        {
            ID = Guid.NewGuid().ToString("N");
        }
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}