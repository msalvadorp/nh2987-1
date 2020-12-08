using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Sol.NHI.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sol.NHI.ApiConsulta.Helpers
{
    public class TopicSuscribeHelper : BackgroundService
    {
        private readonly ISubscriptionClient subscriptionClient;

        public TopicSuscribeHelper(ISubscriptionClient subscriptionClient)
        {
            this.subscriptionClient = subscriptionClient;
             
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            subscriptionClient.RegisterMessageHandler(
                (message, token) => {

                    byte[] dataByte = message.Body;
                    string data = Encoding.UTF8.GetString(dataByte);

                    TransferenciaDatosDTO receive = JsonConvert.DeserializeObject<TransferenciaDatosDTO>(data);

                    return subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
                }, new MessageHandlerOptions(ex =>
                {

                    return Task.FromException(ex.Exception);

                })
                {
                    AutoComplete = false,
                    MaxConcurrentCalls = 1
            });
        }
    }
}
