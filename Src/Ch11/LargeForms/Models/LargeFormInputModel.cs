//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch11 - Posting Data from Client-side
//   LargeForms
//

using System.Collections.Generic;

namespace Ch11.LargeForms.Models
{
    public class LargeFormInputModel
    {
        public LargeFormInputModel()
        {
            Emails = new List<string>();
        }

        public IList<string> Emails { get; set; }
        public string ContactName { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }
}