//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   MyClientApp
//

using System;
using System.Net.Http;
using IdentityModel.Client;

namespace Ch10.MyClientApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start.");
            Console.ReadLine();

            // Discover endpoints from metadata
            var disco = DiscoveryClient.GetAsync("http://localhost:6000").Result;
            //var tokenClient = new TokenClient(disco.TokenEndpoint,
            //    "public-account", "public-account-secret");
            var tokenClient = new TokenClient(disco.TokenEndpoint,
                "internal-account", "internal-account-secret");

            // RO is one of the SCOPE on the API resource 
            var tokenResponse = tokenClient
                .RequestClientCredentialsAsync("FULL").Result;    // Pass scope info
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                Console.WriteLine("Press any key.");
                Console.ReadLine();
                return;
            }

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            // This call just REQUIRES the api resource scope
            //var response = client.GetAsync("http://localhost:6002/weather/now").Result;

            // This call REQUIRES client_scope=internal-only "in addition" to the api resource scope
            var response = client.GetAsync("http://localhost:6002/weather/forecasts").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
            }

            Console.WriteLine("Press any key.");
            Console.ReadLine();
        }
    }
}
