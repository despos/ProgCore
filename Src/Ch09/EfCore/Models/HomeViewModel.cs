//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Securing the Application
//   EfCore
// 

using System.Collections.Generic;
using Ch09.EfCore.Backend.Persistence.Model;

namespace Ch09.EfCore.Models
{
    public class HomeViewModel  
    {
        public IList<Customer> Records { get; set; }
    }
}