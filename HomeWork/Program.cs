using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("First Name: Alisher");
            Console.WriteLine("Last Name: Kalabaev");
            Console.WriteLine();
            //2
            const int NULL = 0;
            int numbersCount, numbersSum = NULL;
            Console.Write("Set numbers count: ");
            numbersCount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write("Set " + (i + 1) + " number: ");
                numbersSum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            Console.WriteLine("Sum of numbers: " + numbersSum);

            Console.ReadLine();
        }
    }
}
