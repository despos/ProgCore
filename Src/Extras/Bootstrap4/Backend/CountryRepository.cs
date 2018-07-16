///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Bs4.Backend
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
            const string resource = "Bs4.Backend.Countries.json";

            var assembly = typeof(Country).Assembly;
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
