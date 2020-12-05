using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Models.DTOS
{
    public class OperationInsertResquestDTO
    {
        public int CuentaOrigen { get; set; }
        public int CuentaDestino { get; set; }
        public decimal Monto { get; set; }

    }
}
