//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   PartialRendering
//

using System.Collections.Generic;
using Ch12.PartialRendering.Backend;

namespace Ch12.PartialRendering.Models
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel(IList<Customer> customers)
        {
            Customers = customers;
        }

        public IList<Customer> Customers { get; private set; }
    }
}