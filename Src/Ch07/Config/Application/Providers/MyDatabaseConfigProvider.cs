//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Config
//  

using Microsoft.Extensions.Configuration;

namespace Ch07.Config.Application.Providers
{
    public class MyDatabaseConfigProvider : ConfigurationProvider
    {
        private const string ConnectionString = "...";

        public override void Load()
        {
            //using (var db = new MyDatabaseContext(ConnectionString))
            //{
            //    db.Database.EnsureCreated();
            //    Data = !db.Values.Any()
            //        ? GetDefaultValues(db)
            //        : db.Values.ToDictionary(c => c.Id, c => c.Value);
            //}

            //private IDictionary<string, string> GetDefaultValues(MyDatabaseContext db)
            //{
            //    // Pseudo code for determining default values to use
            //    var values = DetermineDefaultValues();

            //    // Save default values to the store. 
            //    // NOTE: Values is a DbSet<T> in the DbContext being used.
            //    db.Values.AddRange(values);
            //    db.SaveChanges();

            //    // Return configuration values
            //    return values;
            //}

        }

    }
}