//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   MiniWeb
//

using System.Linq;
using CoreBook.MiniWeb.Persistence.Model;

namespace MiniWeb.Persistence.Abstractions
{
    public interface ICountryRepository
    {
        IQueryable<Country> All();
        Country Find(string code);
        IQueryable<Country> AllBy(string filter);
    }
}
