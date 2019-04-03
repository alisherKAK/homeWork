using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TableCreator : DataBase
    {
        public void CreateStandardTable()
        {
            string query = "create table [gruppa]" +
                "(Id int primary key identity not null," +
                "[Name] nvarchar(50) not null check([Name]!='') )";

            using (var command = new SqlCommand(query, _connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(SqlException exception)
                {
                    throw;
                }
                catch(Exception exception)
                {
                    throw;
                }
            }
        }
    }
}
