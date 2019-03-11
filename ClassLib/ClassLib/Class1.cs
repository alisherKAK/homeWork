using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class PC
    {
        public string ModelName { get; set; }
        public int SerialNumber { get; set; }
        public double EnergyConsumption { get; set; }
        public double ProcessorPower { get; set; }

        public PC(){}
        public PC(string modelName, int serialNumber, double energyConsumption, double processorPower)
        {
            ModelName = modelName;
            SerialNumber = serialNumber;
            EnergyConsumption = energyConsumption;
            ProcessorPower = processorPower;
        }

        public void PowerON()
        {
            Random random = new Random();
            ProcessorPower = random.Next(5);
        }
        public void PowerOFF()
        {
            EnergyConsumption = 0;
            ProcessorPower = 0;
        }
    }
}
