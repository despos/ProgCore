//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using System.Collections.Generic;
using Ch09.EfCore.Backend.Persistence.Model;

namespace Ch09.EfCore.Models
{
    public class RecordViewModel  
    {
        public RecordViewModel()
        {
            Customer = new Customer();
        }

        public Customer Customer { get; set; }
    }
}