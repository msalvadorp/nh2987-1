using Sol.NHI.ApiPersona.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiPersona.Services
{
    public interface IPersonaService
    {
        Task<List<Persona>> List();
        Task<Persona> Get(int id);
    }
}
