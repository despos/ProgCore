//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using System.Collections.Generic;
using System.Linq;
using Ch09.EfCore.Backend.Persistence.Model;

namespace Ch09.EfCore.Backend.Persistence.DomainServices
{
    public class RecordRepository  
    {
        public IList<Customer> GetRecords()
        {
            using (var db = new YourDatabase())
            {
                var list = (from c in db.Customers select c).ToList();
                return list;
            }
        }

        public void Save(Customer customer)
        {
            using (var db = new YourDatabase())
            {
                var existing = (from c in db.Customers
                    where c.Id == customer.Id
                    select c).SingleOrDefault();
                if (existing == null)
                {
                    db.Customers.Add(customer);
                }
                else
                {
                    existing.FirstName = customer.FirstName;
                    existing.LastName = customer.LastName;
                }
                db.SaveChanges();
            }
        }
    }
}
