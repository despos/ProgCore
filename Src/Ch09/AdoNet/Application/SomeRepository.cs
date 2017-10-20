//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   AdoNet
// 

using System.Data;
using System.Data.SqlClient;
using Ch09.AdoNet.Common;

namespace Ch09.AdoNet.Application
{
    public class SomeRepository  
    {
        public DataTable GetRecords()
        {
            var conn = new SqlConnection {ConnectionString = ConnectionStrings.ProgCore };
            var cmd =
                new SqlCommand("SELECT TOP 20 FirstName, LastName, Country FROM customers", conn)
                {
                    CommandType = CommandType.Text
                };
            var table = new DataTable("Results");
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            //conn.Open();
            //var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //var table = new DataTable("Results");
            //table.Columns.Add("FirstName");
            //table.Columns.Add("LastName");
            //table.Columns.Add("Country");
            //table.Load(reader);
            //while (reader.Read())
            //{
            //   table.Rows.Add(reader[0], reader[1], reader[2]);
            //}
            //reader.Close();

            return table;
        }
    }
}
