using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Hotel.DataAccess
{
    public class TableDataService<T> : DbRepository
    {
        public List<T> GetAll()
        {
            Type type = typeof(T);

            string query = $"select * from {type.Name}s";
            using (var command = new SqlCommand(query, _connection))
            using (var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    for(int i = 0; i < type.GetProperties().Length; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                    }
                }
            }

            return new List<T>();
        }
    }
}
