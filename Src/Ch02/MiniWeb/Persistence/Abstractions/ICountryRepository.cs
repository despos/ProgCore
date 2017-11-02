//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   MiniWeb
//

using System.Linq;
using Ch02.MiniWeb.Persistence.Model;

namespace Ch02.MiniWeb.Persistence.Abstractions
{
    public interface ICountryRepository
    {
        IQueryable<Country> All();
        Country Find(string code);
        IQueryable<Country> AllBy(string filter);
    }
}
