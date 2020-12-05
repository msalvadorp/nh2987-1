using Sol.NHI.ApiPersona.Contexto;
using Sol.NHI.ApiPersona.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Sol.NHI.ApiPersona.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly PersonaContext personaContext;

        public PersonaService(PersonaContext personaContext)
        {
            this.personaContext = personaContext;
        }
        public async Task<Persona> Get(int id)
        {
            return await personaContext.Persona.FirstOrDefaultAsync(t => t.IdPersona == id);
        }

        public async Task<List<Persona>> List()
        {
            return await personaContext.Persona.ToListAsync();
        }
    }
}
