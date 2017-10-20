//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Config
//    

using Microsoft.Extensions.Configuration;

namespace Ch07.Config.Application.Providers
{
    public class MyDatabaseConfigSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MyDatabaseConfigProvider();
        }
    }
}