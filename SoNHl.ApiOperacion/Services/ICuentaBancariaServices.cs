using SoNHl.ApiOperacion.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Services
{
    public interface ICuentaBancariaServices
    {
        Task<CuentaBancaria> RecuperarCuentaBancaria(int IdCuenta);
    }
}
