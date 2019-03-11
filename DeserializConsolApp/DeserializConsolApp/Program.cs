using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ClassLib;

namespace DeserializConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream fs = new FileStream(@"D:\listSerial.txt", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                List<PC> pCs = formatter.Deserialize(fs) as List<PC>;

                foreach(PC pc in pCs)
                {
                    Console.WriteLine($"{pc.ModelName}; {pc.SerialNumber}; {pc.EnergyConsumption}; {pc.ProcessorPower}");
                }
            }
        }
    }
}
