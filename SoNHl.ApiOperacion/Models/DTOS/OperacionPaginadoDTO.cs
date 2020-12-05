using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Models.DTOS
{
    public class OperacionPaginadoDTO
    {

        public int TotalReg { get; set; }
        public List<Operacion> Operaciones { get; set; }
    }
}
