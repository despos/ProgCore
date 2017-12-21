//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using Ch09.EfCore.Backend.Persistence.DomainServices;
using Ch09.EfCore.Backend.Persistence.Model;
using Ch09.EfCore.Models;

namespace Ch09.EfCore.Application
{
    public class RecordService
    {
        private readonly RecordRepository _repo;

        public RecordService(RecordRepository repo)
        {
            _repo = repo;
        }

        public RecordViewModel GetNewRecordViewModel()
        {
            var model = new RecordViewModel
            {
                Customer = {FirstName = "Dino"}
            };
            return model;
        }

        public void SaveRecord(string fn, string ln)
        {
            var customer = new Customer();
            customer.FirstName = fn;
            customer.LastName = ln;
            _repo.Save(customer);
        }
    }
}
