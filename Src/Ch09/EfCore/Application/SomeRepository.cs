//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Securing the Application
//   EfCore
// 

using System.Collections.Generic;
using System.Linq;
using Ch09.EfCore.Backend.Persistence;
using Ch09.EfCore.Backend.Persistence.Model;

namespace Ch09.EfCore.Application
{
    public class SomeRepository  
    {
        public IList<Customer> GetRecords()
        {
            using (var db = new YourDatabase())
            {
                var list = (from c in db.Customers select c).ToList();
                return list;
            }
        }
    }
}
