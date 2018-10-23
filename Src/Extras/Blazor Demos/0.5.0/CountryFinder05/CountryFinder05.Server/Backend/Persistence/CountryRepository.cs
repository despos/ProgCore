//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.5.0)
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using CountryFinder05.Shared.Model;



namespace CountryFinder05.Server.Backend.Persistence
{
    public class CountryRepository
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
                    where c.CountryCode.Equals(code, StringComparison.InvariantCultureIgnoreCase)
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
            const string resource = "CountryFinder05.Server.Backend.Persistence.Countries.json";

            var assembly = typeof(CountryRepository).Assembly;
            using (var stream = assembly.GetManifestResourceStream(resource))
            {
                if (stream == null)
                    return new List<Country>();

                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    var countries = JsonConvert.DeserializeObject<Country[]>(json);
                    return countries.OrderBy(c => c.CountryName).ToList();
                }
            }
        }
        #endregion
    }
}
