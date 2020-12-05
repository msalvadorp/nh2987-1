using Microsoft.EntityFrameworkCore;
using Sol.NHI.ApiPersona.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiPersona.Contexto
{
    public class PersonaContext : DbContext
    {
        public PersonaContext(DbContextOptions<PersonaContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Persona>().HasData(
                new Persona { IdPersona = 1, ApellidoPaterno = "Perez", ApellidoMaterno = "Gomez", Nombres = "Juan Perez" },
                new Persona { IdPersona = 2, ApellidoPaterno = "Lopez", ApellidoMaterno = "Caceres", Nombres = "Maria" }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Persona> Persona { get; set; }
    }
}
