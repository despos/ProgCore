//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   MiniWeb
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ch02.MiniWeb.Persistence.Abstractions;
using Ch02.MiniWeb.Persistence.Model;
using Newtonsoft.Json;

namespace Ch02.MiniWeb.Persistence
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
