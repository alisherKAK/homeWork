using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Hotel.DataAccess
{
    public class DbRepository : IDisposable
    {
        protected DbConnection _connection;
        private DbProviderFactory _providerFactory;

        public DbRepository()
        {
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["HotelDbConnectionString"].ProviderName);
            _connection = _providerFactory.CreateConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["HotelDbConnectionString"].ConnectionString;
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public List<string> GetTables()
        {
            List<string> tabels = new List<string>();
            string query = "select * from sysobjects where xtype='U'";

            using (var command = _connection.CreateCommand())
            {
                command.CommandText = query;
                try
                {
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tabels.Add(reader.GetString(0));
                    }

                    return tabels;
                }
                catch (DbException exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
            }
        }
    }
}
