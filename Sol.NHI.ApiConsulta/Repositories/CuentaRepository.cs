using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Sol.NHI.ApiConsulta.Models.Configs;
using Sol.NHI.ApiConsulta.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.NHI.ApiConsulta.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly IMongoClient mongoClient;
        private readonly IMongoDatabase mongoDb;
        private readonly IMongoCollection<Cuenta> collection;

        public CuentaRepository(IOptions<CnnMongoConfig> options)
        {
            mongoClient = new MongoClient(options.Value.Server);
            mongoDb = mongoClient.GetDatabase(options.Value.DataBase);
            collection = mongoDb.GetCollection<Cuenta>(options.Value.Collection);
        }

        public async Task<Cuenta> Insertar(Cuenta cuenta)
        {
            cuenta.auto = ObjectId.GenerateNewId();
            await collection.InsertOneAsync(cuenta);
            return cuenta;
        }

        public async Task<List<Cuenta>> Listar()
        {
            List<Cuenta> iistado = await collection.Find(t => true).ToListAsync();
            return iistado;
        }
    }
}
