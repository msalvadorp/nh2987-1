using SoNHl.ApiOperacion.Contexto;
using SoNHl.ApiOperacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoNHl.ApiOperacion.Models.DTOS;

namespace SoNHl.ApiOperacion.Services
{
    public class OperacionService : IOperacionService
    {
        private OperacionContext _operacionContext;
        public OperacionService(OperacionContext operacionContext)
        {
            _operacionContext = operacionContext;
        }

        public Operacion Actualizar(Operacion operacion)
        {
            throw new NotImplementedException();
        }

        public async Task<Operacion> Insertar(Operacion operacion)
        {
            _operacionContext.Operacion.Add(operacion);
            await _operacionContext.SaveChangesAsync();
            return operacion;
        }

        public async Task<List<Operacion>> Listar()
        {
            return await _operacionContext.Operacion.ToListAsync();
        }

        public async  Task<OperacionPaginadoDTO> ListarPaginado(int size, int numpag)
        {

            OperacionPaginadoDTO res = new OperacionPaginadoDTO();

            var query = (from x in _operacionContext.Operacion
                         select x);
            int skipReg = (numpag - 1) * size;
            //if (size > 10)
            //{
            //    query = query.Where(t => t.IdCuentaDestino > 10);
            //}
            res.TotalReg = query.Count();
            res.Operaciones = 
                await query.Skip(skipReg).Take(size).AsNoTracking().ToListAsync();

            return res;

        }

        public async Task<Operacion> Recuperar(int id)
        {
            Operacion op = (from x in _operacionContext.Operacion
                            where x.IdOperacion == id
                            select x).FirstOrDefault();

            op = await _operacionContext.Operacion
                .FirstOrDefaultAsync(t => t.IdOperacion == id);

            return op;
        }
    }
}
