using SoNHl.ApiOperacion.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Applications
{
    public interface IOperacionApplication
    {
        OperationInsertResponseDTO ProcessTranser
            (OperationInsertResquestDTO operationInsertResquestDTO);

    }
}
