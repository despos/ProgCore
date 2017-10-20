//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Securing the Application
//   EfCore
// 

using Microsoft.EntityFrameworkCore;
using Ch09.EfCore.Backend.Persistence.Model;

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