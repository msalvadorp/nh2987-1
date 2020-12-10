using Sol.NHI.ApiConsulta.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiConsulta.Repositories
{
    public interface ICuentaRepository
    {
        Task<Cuenta> Insertar(Cuenta cuenta);
        Task<List<Cuenta>> Listar();
    }
}
