//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using System.Collections.Generic;
using SignalR1.Backend;

namespace SignalR1.Models
{
    public class CustomersViewModel : ViewModelBase
    {
        public CustomersViewModel(IList<Customer> customers)
        {
            Customers = customers;
        }

        public IList<Customer> Customers { get; private set; }
    }
}