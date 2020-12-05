using Microsoft.AspNetCore.Mvc;
using Sol.NHI.ApiPersona.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiPersona.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
 

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            if (id > 1000)
            {
                return BadRequest("El codigo esta errado");
            }

            Persona p = new Persona()
            {
                IdPersona = id,
                Nombres = $"Persona {id}"
            };
            return Ok(p);
        }

        [HttpPost]
        public IActionResult Grabar( Persona persona) {

            persona.IdPersona = 1000;
            return Ok(persona);
        
        }

    }
}
