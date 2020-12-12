using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Sol.NHI.ApiIdentityServer.Helpers
{
    public class IdentityServerConfig
    {

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[] {
                new IdentityResources.OpenId()
            };

        }

        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {
                new ApiResource("apiconsulta", "MyActions API")
                {
                    Scopes = { "apiconsulta" }
                },
                new ApiResource("apioperacion", "Mi Api de Operacion")
                {
                    Scopes = { "apioperacion" }
                },
                new ApiResource("apiplanilla", "Comentario API")
                {
                    Scopes = { "apirest" }
                }
           };


        public static IEnumerable<ApiScope> ApiScopes =>
         new ApiScope[]
         {
                    new ApiScope("apiconsulta", "MyActions API"),
                    new ApiScope("apioperacion", "MyActions API")
         };


        public static IEnumerable<Client> GetClients()
        {

            List<Client> listado = new List<Client>();

            Client c1 = new Client
            {
                ClientId = "appmovil",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("123".Sha256()) },
                AllowedScopes = { "apioperacion" }
            };

            listado.Add(c1);

            return listado;
        }

        public static List<TestUser> GestUsers()
        {

            return new List<TestUser>{

            new TestUser {SubjectId = "1", Username = "jperez", Password="654321"},
            new TestUser {SubjectId = "2", Username = "mlopez", Password="654321"}
            };

        }

    }
}
