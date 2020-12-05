using SoNHl.ApiOperacion.Models;
using SoNHl.ApiOperacion.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Services
{
    public interface IOperacionService
    {

        Task<List<Operacion>> Listar();
        Task<Operacion> Recuperar(int id);
        Task<Operacion> Insertar(Operacion operacion);
        Operacion Actualizar(Operacion operacion);

        Task<OperacionPaginadoDTO> ListarPaginado(int size, int nnumpag);
    }
}
