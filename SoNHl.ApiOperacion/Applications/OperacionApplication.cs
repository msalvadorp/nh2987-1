using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sol.NHI.Common.DTO;
using SoNHl.ApiOperacion.Models.DTOS;
using SoNHl.ApiOperacion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Applications
{
    public class OperacionApplication : IOperacionApplication
    {
        private readonly IOperacionService operacionService;
        private readonly IOptions<BusConfigDTO> options;

        public OperacionApplication(
            IOperacionService operacionService,
            IOptions<BusConfigDTO> options)
        {
            this.operacionService = operacionService;
            this.options = options;
        }
        public async Task<OperationInsertResponseDTO> ProcessTranser(OperationInsertResquestDTO operationInsertResquestDTO)
        {
            /*
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await
               client.GetAsync("http://localhost:6559/persona/1");

            PersonaDTO per = await res.Content.ReadAsAsync<PersonaDTO>();
            */
            //enviar al servidor de colas
            #region Envio al Servicio
            TransferenciaDatosDTO dtoTopic = new TransferenciaDatosDTO
            {
                Codigo = 1,
                Correo = "jperez@hotmail.com",
                Monto = operationInsertResquestDTO.Monto,
                NombreCompleto = "Juan Perez"
            };

            TopicClient topicClient = new TopicClient(options.Value.Server, options.Value.TopicName);

            string data = JsonConvert.SerializeObject(dtoTopic);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            Message message = new Message(dataBytes);

            await topicClient.SendAsync(message);
            #endregion

            return new OperationInsertResponseDTO { Codigo = 1, Fecha = DateTime.Now };

        }
    }
}
