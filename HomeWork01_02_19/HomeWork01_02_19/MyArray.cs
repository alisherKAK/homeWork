using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork01_02_19
{
    public class MyArray
    {
        public int[] Numbers { get; set; }
        public int this[int index]
        {
            get
            {
                return Numbers[index];
            }
            set
            {
                Numbers[index] = value;
            }
        }


        public static bool operator>(MyArray firstArray, MyArray secondArray)
        {
            int firstArrayNumbersSum = Constants.NULL;
            int secondArrayNumbersSum = Constants.NULL;

            for(int i = 0; i < firstArray.Numbers.Length; i++)
            {
                firstArrayNumbersSum += firstArray[i];
            }
            for (int i = 0; i < secondArray.Numbers.Length; i++)
            {
                firstArrayNumbersSum += secondArray[i];
            }

            if(firstArrayNumbersSum > secondArrayNumbersSum)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(MyArray firstArray, MyArray secondArray)
        {
            return !(firstArray > secondArray);
        }

    }
}
