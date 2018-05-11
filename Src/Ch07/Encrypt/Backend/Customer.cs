//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Encrypt
//   

using System;

namespace Ch07.Encrypt.Backend
{
    public class Customer 
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string LastUpdate { get; set; }
    }
}