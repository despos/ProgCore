//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Encrypt
//   

using System;
using System.IO;
using Microsoft.AspNetCore.DataProtection;

namespace Ch07.Encrypt.Backend
{
    public class Repository
    {
        private readonly IDataProtector _protector;

        public Repository(IDataProtectionProvider protectorProvider)
        {
            _protector = protectorProvider.CreateProtector("Current.User.Data");
        }

        public void Save(Customer customer)
        {
            var buffer = new StringWriter();
            buffer.Write(DateTime.Now.ToString("G") + ",");
            buffer.Write(customer.Name + ",");
            buffer.Write(customer.City + ",");
            buffer.Write(customer.Country + "\r\n");
            var input = buffer.ToString();
            buffer.Close();

            var writer = new StreamWriter("sample.txt");
            string protectedInput = _protector.Protect(input);
            writer.Write(protectedInput);
            writer.Close();
        }

        public Customer Load()
        {
            var reader = new StreamReader("sample.txt");
            var protectedContent = reader.ReadLine();
            if (protectedContent == null)
                return new Customer();

            var content = _protector.Unprotect(protectedContent);
            reader.Close();
            var parts = content.Split(',');
            var customer = new Customer
            {
                LastUpdate = parts[0],
                Name = parts[1],
                City = parts[2],
                Country = parts[3]
            };
            return customer;
        }
    }
}