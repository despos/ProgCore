//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Securing the Application
//   EfCore
// 

using Ch09.EfCore.Models;

namespace Ch09.EfCore.Application
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
