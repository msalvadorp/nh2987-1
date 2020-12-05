using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Models
{
    public class Operacion
    {
        [Key]
        public int IdOperacion { get; set; }
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaOperacion { get; set; }

    }
}
