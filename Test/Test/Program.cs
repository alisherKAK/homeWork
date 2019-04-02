using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Id = 4, FullName = "kfkvf", Age=35, Yes = true
            };

            TableDataService<User> service = new TableDataService<User>();

            service.Add(user);

            Console.ReadLine();
        }
    }
}
