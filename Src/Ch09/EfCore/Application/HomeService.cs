//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using Ch09.EfCore.Backend.Persistence.DomainServices;
using Ch09.EfCore.Models;

namespace Ch09.EfCore.Application
{
    public class HomeService
    {
        private readonly RecordRepository _repo;

        public HomeService(RecordRepository repo)
        {
            _repo = repo;
        }

        public HomeViewModel GetHomeViewModel()
        {
            var model = new HomeViewModel {Records = _repo.GetRecords()};
            return model;
        }
    }
}
