using Microsoft.EntityFrameworkCore;
using SoNHl.ApiOperacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoNHl.ApiOperacion.Contexto
{
    public class OperacionContext : DbContext
    {
        public OperacionContext
            (DbContextOptions<OperacionContext> options)
                : base(options)
        {

        }


        public DbSet<Operacion> Operacion { get; set; }

    }
}
