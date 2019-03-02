using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork10_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Введите путь до файла:");

            string path = Console.ReadLine().Trim();
            string numbersToWrite = " ";
            string result;

            using (StreamReader file = new StreamReader(path))
            {
                result = file.ReadToEnd().Trim();

                string[] numbers = result.Split();

                int firstNumber = int.Parse(numbers[numbers.Length - Consants.PRELAST_ELEMENT]);
                int secondNumber = int.Parse(numbers[numbers.Length - Consants.LENTH_TO_INDEX]);
                Console.WriteLine(firstNumber + " " + secondNumber);

                for(int i = 0; i < numbers.Length - Consants.LENTH_TO_INDEX; i++)
                {
                    secondNumber = firstNumber + secondNumber;
                    firstNumber = secondNumber - firstNumber;
                    numbersToWrite += secondNumber.ToString() + " ";
                }
            }

            numbersToWrite = numbersToWrite.Trim();

            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(result + " " + numbersToWrite);
            }

            //2
            Console.WriteLine("Введите путь до файла:");

            path = Console.ReadLine().Trim();


            int numberResult;

            using (StreamReader reader = new StreamReader(path))
            {
                int firstNumber;
                int secondNumber;

                result = reader.ReadToEnd().Trim();

                firstNumber = int.Parse(result.Split()[Consants.FIRST_ELEMENT]);
                secondNumber = int.Parse(result.Split()[Consants.SECOND_ELEMENT]);

                numberResult = firstNumber + secondNumber;
            }

            Console.WriteLine("Введите путь сохранение:");

            string savePath = Console.ReadLine().Trim();

            Console.WriteLine("Введите имя файла:");

            string name = Console.ReadLine().Trim();

            savePath += name;

            using (FileStream file = File.Create(savePath))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(numberResult.ToString());

                file.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
