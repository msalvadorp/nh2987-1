using Microsoft.AspNetCore.Mvc;
using Sol.NHI.ApiPersona.Helpers.Filters;
using Sol.NHI.ApiPersona.Model;
using Sol.NHI.ApiPersona.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiPersona.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService personaService;

        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Recuperar(int id)
        {
            Persona p = await personaService.Get(id);
            
            if (p == null)
            {
                //throw new Exception("Error al consultar la persona");
                return BadRequest("El codigo esta errado");
            }
            return Ok(p);
        }

        [HttpPost]
        [AutorizaFilter]
        public async Task<IActionResult> Grabar([FromBody] Persona persona) {
            if (ModelState.IsValid)
            {
                List<Persona> lista = await personaService.List();
                return Ok(lista);
            }
            else
            {
                /*
                List<ValidaModelResponse> lista = new List<ValidaModelResponse>();

                foreach (KeyValuePair<string, ModelStateEntry> item in ModelState)
                {
                    if (item.Value.Errors.Any())
                    {
                        ValidaModelResponse vmr = new ValidaModelResponse();
                        vmr.attribute = item.Key;
                        vmr.message = new List<string>();
                        foreach (var itemError in item.Value.Errors)
                        {
                            vmr.message.Add(itemError.ErrorMessage);
                        }
                        lista.Add(vmr);
                    }
                }
                */
                return BadRequest("La estrucutra no corresponde");
            }
           
        
        }

    }
}
