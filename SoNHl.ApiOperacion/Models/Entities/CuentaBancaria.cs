using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Models.Entities
{
    public class CuentaBancaria
    {
        public int IdCuentaBancaria { get; set; }
        public int IdPersona { get; set; }
        public decimal Saldo { get; set; }

    }
}
