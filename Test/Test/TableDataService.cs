using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TableDataService<T> : DbRepository
    {
        public List<T> GetAll()
        {
            Type type = typeof(T);
            var data = new List<T>();
            var properties = type.GetProperties();

            string query = $"select * from {type.Name}s";
            using (var command = new SqlCommand(query, _connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = (T)Activator.CreateInstance(type);

                    for (int i = 0; i < properties.Length; i++)
                    {
                        properties[i].SetValue(item, reader[i]);
                    }

                    data.Add(item);
                }
            }

            return data;
        }

        public void Add(T item)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            string query = $"insert into {type.Name}s values(";
            for(int i = 1; i < properties.Length; i++)
            {
                Console.WriteLine(properties[i].GetValue(item).GetType().Name);
                if (properties[i].GetValue(item).GetType().Name == "String" ||
                    properties[i].GetValue(item).GetType().Name == "string")
                {
                    query += $"'{properties[i].GetValue(item).ToString()}',";
                }
                else if(properties[i].GetValue(item).GetType().Name == "Boolean")
                {
                    if((bool)properties[i].GetValue(item) == true)
                        query += "1,";
                    else
                        query += "0,";
                }
                else
                {
                    query += $"{properties[i].GetValue(item).ToString()},";
                }
            }
            query = query.Trim(',');
            query += ")";

            Console.WriteLine(query);

            using (var command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
