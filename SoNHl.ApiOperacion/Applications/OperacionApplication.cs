using SoNHl.ApiOperacion.Models.DTOS;
using SoNHl.ApiOperacion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Applications
{
    public class OperacionApplication : IOperacionApplication
    {
        private readonly IOperacionService operacionService;

        public OperacionApplication(IOperacionService operacionService)
        {
            this.operacionService = operacionService;
        }
        public OperationInsertResponseDTO ProcessTranser(OperationInsertResquestDTO operationInsertResquestDTO)
        {
            //llamada a ApiPeraona
            throw new NotImplementedException();
        }
    }
}
