using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_04_19
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var creator = new TableCreator())
            {
                try
                {
                    creator.CreateStandardTable();
                }
                catch(SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
