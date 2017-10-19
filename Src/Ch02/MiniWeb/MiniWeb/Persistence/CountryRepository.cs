//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   MiniWeb
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CoreBook.MiniWeb.Persistence.Model;
using MiniWeb.Persistence.Abstractions;
using Newtonsoft.Json;

namespace MiniWeb.Persistence
{
    public class CountryRepository : ICountryRepository
    {
        private static IList<Country> _countries; 

        public IQueryable<Country> All()
        {
            EnsureCountriesAreLoaded();
            return _countries.AsQueryable();
        }
        
        public Country Find(string code)
        {
            return (from c in All()
                    where c.CountryCode.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                    select c).FirstOrDefault();
        }

        public IQueryable<Country> AllBy(string filter)
        {
            return String.IsNullOrEmpty(filter) 
                ? All()
                : (All().Where(c => c.CountryName.ToLower().StartsWith(filter.ToLower())));
        }

        #region PRIVATE
        private static void EnsureCountriesAreLoaded()
        {
            if (_countries == null)
                _countries = LoadCountriesFromStream();
        }

        private static IList<Country> LoadCountriesFromStream()
        {
            var json = File.ReadAllText("countries.json");
            var countries = JsonConvert.DeserializeObject<Country[]>(json);
            return countries.OrderBy(c => c.CountryName).ToList();
        }
        #endregion
    }
}
