using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleRural.Models
{
    public class Vacina
    {
        public int Id { get; set; }
        public int NumeroLote { get; set; }
        public DateTime DataCompra { get; set; }
        public string TipoVacina { get; set; }
        public DateTime Vencimento { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public string IdUsuario { get; set; }

    }
}