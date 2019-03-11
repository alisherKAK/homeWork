using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLib;

namespace SerializConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> pcList = new List<PC>();

            int pcCount = SetCount();

            for (int i = 0; i < pcCount; i++)
            {
                PC newPC = new PC
                {
                    ModelName = SetModelName(),
                    SerialNumber = SetSerialNumber(),
                    EnergyConsumption = SetEnergyConsumption(),
                    ProcessorPower = SetProcessorPower()
                };

                pcList.Add(newPC);
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(@"D:\listSerial.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pcList);
            }
        }
        static string SetModelName()
        {
            try
            {
                Console.WriteLine("Введите имя модели компьютера:");

                string modelName = Console.ReadLine().Trim();

                foreach(char letter in modelName)
                {
                    if ( !((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z') ||
                        (letter >= '0' && letter <= '9') || letter == ' ') )
                    {
                        throw new ArgumentException("Модель компьютера введено неверно");
                    }
                }

                return modelName;
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetModelName();
            }
        }
        static int SetSerialNumber()
        {
            try
            {
                Console.WriteLine("Введите сериный номер компьютера:");

                int serialNumber;

                if(int.TryParse(Console.ReadLine().Trim(), out serialNumber))
                {
                    return serialNumber;
                }

                throw new ArgumentException("Сериный номер был введен неверно");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetSerialNumber();
            }
        }
        static double SetEnergyConsumption()
        {
            try
            {
                Console.WriteLine("Введите энергопотребление компьютера:");

                double energyConsumption;

                if (double.TryParse(Console.ReadLine().Trim(), out energyConsumption))
                {
                    return energyConsumption;
                }

                throw new ArgumentException("Энергопотребление было введено неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetEnergyConsumption();
            }
        }
        static double SetProcessorPower()
        {
            try
            {
                Console.WriteLine("Введите мощность процессора компьютера:");

                double processorPower;

                if (double.TryParse(Console.ReadLine().Trim(), out processorPower))
                {
                    return processorPower;
                }

                throw new ArgumentException("Мощность процессора было введено неверно");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetProcessorPower();
            }
        }
        static int SetCount()
        {
            try
            {
                Console.WriteLine("Введите кол пк:");

                int pcCount;

                if (int.TryParse(Console.ReadLine().Trim(), out pcCount))
                {
                    return pcCount;
                }

                throw new ArgumentException("Кол было введено неверно");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetCount();
            }
        }
    }
}
