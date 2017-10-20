//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   MyIdentityServer
//

using System.Collections.Generic;
using IdentityServer4.Models;

namespace Ch10.MyIdentityServer.Common
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("fun-API", "My fabulous fun API"),
                new ApiResource
                {
                    Name = "weather-API",
                    DisplayName = "My fabulous weather API (scoped)",
                    Scopes =
                    {
                        new Scope {Name="FULL"},
                        new Scope {Name="RO"},
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                { 
                    ClientId = "internal-account",
                    ClientSecrets =
                    {
                        new Secret("internal-account-secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"FULL", "RO"}
                    //AllowedScopes = { "weather-API" },
                    //Claims = { new Claim("scope", "internal") },
                },
                new Client
                {
                    ClientId = "public-account",
                    ClientSecrets =
                    {
                        new Secret("public-account-secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"RO"}
                    //AllowedScopes = { "weather-API" }
                }
            };
        }
    }
}