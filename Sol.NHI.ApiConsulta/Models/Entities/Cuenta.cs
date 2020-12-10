using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sol.NHI.ApiConsulta.Models.Entities
{
    public class Cuenta
    {
        [BsonId]
        [BsonElement("auto")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId auto { get; set; }

        [BsonElement("idcliente")]
        public int IdCliente { get; set; }
        [BsonElement("nombrecompleto")]
        public string NombreCompleto { get; set; }
        [BsonElement("correo")]
        public string Correo { get; set; }
        [BsonElement("saldo")]
        public decimal Saldo { get; set; }
    }
}
