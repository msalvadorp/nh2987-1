using Microsoft.AspNetCore.Mvc;
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

        public CuentaController(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Save(Cuenta cuenta)
        {
            return Ok(await cuentaRepository.Insertar(cuenta));
        }


        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await cuentaRepository.Listar());
        }
    }
}
