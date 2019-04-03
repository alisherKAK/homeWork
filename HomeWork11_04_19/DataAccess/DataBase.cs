using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class DataBase : IDisposable
    {
        protected SqlConnection _connection;

        public DataBase()
        {
            _connection = new SqlConnection(ConfigurationManager.AppSettings["DbConnectionString"]);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
