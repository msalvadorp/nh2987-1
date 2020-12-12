using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sol.NHI.ApiConsulta.Models.Entities;
using Sol.NHI.ApiConsulta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiConsulta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository cuentaRepository;
        private readonly ILogger<CuentaController> logger;

        public CuentaController(
            ICuentaRepository cuentaRepository, ILogger<CuentaController> logger )
        {
            this.cuentaRepository = cuentaRepository;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Save(Cuenta cuenta)
        {
            try
            {
                logger.LogWarning("Iniciando grabacion;");
                var tmp = await cuentaRepository.Insertar(cuenta);
                logger.LogWarning("Datos grabados");
                return Ok(tmp);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Nose pudo insertar la cuenta");
                throw;
            }

      
        }


        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await cuentaRepository.Listar());
        }
    }
}
