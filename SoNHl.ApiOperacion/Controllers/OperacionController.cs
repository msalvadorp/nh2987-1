using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoNHl.ApiOperacion.Applications;
using SoNHl.ApiOperacion.Models;
using SoNHl.ApiOperacion.Models.DTOS;
using SoNHl.ApiOperacion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OperacionController : ControllerBase
    {
        private readonly IOperacionApplication operacionApplication;
        private IOperacionService _articuloService;
        public OperacionController(
            IOperacionApplication operacionApplication,
            IOperacionService articuloService)
        {
            this.operacionApplication = operacionApplication;
            _articuloService = articuloService;
        }

        [HttpPost]
        public IActionResult Grabar
            (OperationInsertResquestDTO operationInsertResquestDTO)
        {

            return Ok(operacionApplication.ProcessTranser(operationInsertResquestDTO));
        
        }

        [HttpGet]
        public async Task<OperacionPaginadoDTO> Listar(int size, int numpag)
        {

            HttpClient client = new HttpClient();
            /*
            HttpResponseMessage res = await
                client.GetAsync("http://localhost:6559/persona/20000");
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                PersonaDTO per = await res.Content.ReadAsAsync<PersonaDTO>();

                //string data = await res.Content.ReadAsStringAsync();
                //PersonaDTO persona = JsonConvert.DeserializeObject<PersonaDTO>(data);
            }
            else if (res.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string data = await res.Content.ReadAsStringAsync();
            }
            else
            {

            }
            */
            PersonaDTO persona = new PersonaDTO() { IdPersona = 1, NombreCompleto = "Juan perez" };

            
            HttpResponseMessage res3 = await client.PostAsJsonAsync<PersonaDTO>
                        ("http://localhost:6559/persona/", persona);

            PersonaDTO perRes = await res3.Content.ReadAsAsync<PersonaDTO>();


            OperacionPaginadoDTO lista =
                await _articuloService.ListarPaginado(size, numpag);
            return lista;
        }



        //[HttpGet]
        //public async Task<List<Operacion>> Listar()
        //{

        //    List<Operacion> lista = await _articuloService.Listar();
        //    return lista;
        //}

    }
}
