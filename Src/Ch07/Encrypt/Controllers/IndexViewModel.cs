//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Encrypt
//   

using System.IO;
using Ch07.Encrypt.Backend;
using Microsoft.AspNetCore.DataProtection;

namespace Ch07.Encrypt.Controllers
{
    public class IndexViewModel  
    {
        public Customer TheCustomer { get; set; }
    }
}