using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sol.NHI.ApiConsulta.Helpers;
using Sol.NHI.ApiConsulta.Models.Configs;
using Sol.NHI.ApiConsulta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiConsulta
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers();
            services.Configure<CnnMongoConfig>(Configuration.GetSection("CnnMongo"));

            
            services.AddTransient<ICuentaRepository, CuentaRepository>();

            /*
            services.AddHostedService<TopicSuscribeHelper>();
            services.AddSingleton<ISubscriptionClient>(p => new SubscriptionClient
            (Configuration.GetValue<string>("Bus:Server"),
            Configuration.GetValue<string>("Bus:TopicName"),
            Configuration.GetValue<string>("Bus:SuscriptionName")
            ));
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogError("algun mensaje");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
