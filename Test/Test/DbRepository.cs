using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DbRepository : IDisposable
    {
        protected readonly SqlConnection _connection;

        public DbRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.AppSettings["DB"]);
            _connection.Open();
        }

        public DbRepository(string connection)
        {
            _connection = new SqlConnection(connection);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
