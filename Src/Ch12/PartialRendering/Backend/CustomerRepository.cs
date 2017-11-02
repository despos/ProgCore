//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   PartialRendering
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch12.PartialRendering.Backend
{
    public class CustomerRepository
    {
        private static IList<Customer> _customers;

        public IList<Customer> FindAll()
        {
            if (_customers == null)
                _customers = FindAllInternal();
            return _customers;
        }

        public void Delete(int id)
        {
            var customers = FindAll();
            var customer = (from c in customers where c.Id == id select c).FirstOrDefault();
            customers.Remove(customer);

        }

        private IList<Customer> FindAllInternal()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var list = new List<Customer>();
            for (var i = 0; i < 5; i++)
            {
                var fakeId = rnd.Next(100, 1000);
                var fakeStreetAddressNo = rnd.Next(1, 50);
                var fakeAddressLen = rnd.Next(8, 20);
                list.Add(new Customer
                {
                    Id = fakeId,
                    Name = String.Format("Customer-{0}", fakeId),
                    Address = String.Format("{0} {1}", fakeStreetAddressNo, RandomString(fakeAddressLen))
                });
            }
            return list.OrderBy(c => c.Name).ToList();
        }

        private string RandomString(int size)
        {
            var rng = new Random();
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = alphabet[rng.Next(alphabet.Length)];
            }
            return new string(buffer);
        }
    }
}