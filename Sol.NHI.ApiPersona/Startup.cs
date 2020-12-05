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
            services.AddDbContext<PersonaContext>(
               opt => {
                   opt.UseSqlServer(Configuration.GetValue<string>("CnnDB"));

               });
            services.AddControllers();
            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(opt => {
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(r => {
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
