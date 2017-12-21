//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using Microsoft.EntityFrameworkCore;
using Ch09.EfCore.Backend.Persistence.Model;
using Microsoft.Extensions.Options;

namespace Ch09.EfCore.Backend.Persistence
{
    public class YourDatabase : DbContext
    {
        public static string ConnectionString = "";

        //public YourDatabase(IOptions<ConnectionStringOption> conStrOptions)
        //{

        //}

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}