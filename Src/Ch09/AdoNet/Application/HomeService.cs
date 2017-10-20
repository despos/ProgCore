//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   AdoNet
// 

using Ch09.AdoNet.Models;

namespace Ch09.AdoNet.Application
{
    public class HomeService
    {
        private readonly SomeRepository _repo;

        public HomeService(SomeRepository repo)
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
