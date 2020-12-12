using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Sol.NHI.ApiPersona.Contexto;
using Microsoft.EntityFrameworkCore;
using Sol.NHI.ApiPersona.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;

namespace Sol.NHI.ApiPersona
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

            services.AddApplicationInsightsTelemetry();
            services.AddDbContext<PersonaContext>(
               opt =>
               {
                   opt.UseSqlServer(Configuration.GetValue<string>("CnnDB"));

               });

            services.AddTransient<IPersonaService, PersonaService>();
            services.AddControllers();

            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                string grupo = "V1";

                opt.SwaggerDoc(grupo, new OpenApiInfo
                {
                    Title = $"Api persona {grupo}",
                    Version = grupo,
                    Contact = new OpenApiContact
                    {
                        Name = "Juan Perez",
                        Email = "jperez@hotmail.com",
                        Url = new Uri("http://hotmail.com")
                    },
                    Description = "Api de Maestras de Personas "

                }); ;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            var cadena = Configuration.GetValue<string>("CnnDB");
            logger.LogWarning("Cadena es: " + cadena);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appError =>
                {
                    appError.Run(async context =>
                    {

                        var car = context.Features.Get<IExceptionHandlerFeature>();
                        if (car != null)
                        {
                            Exception detalleError = car.Error;
                           
                        }

                        context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("Tuvimo problemas");
                    });

                });
            }
            app.UseSwagger();
            app.UseSwaggerUI(r =>
            {
                r.SwaggerEndpoint("/swagger/V1/swagger.json", "Api Persona V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
