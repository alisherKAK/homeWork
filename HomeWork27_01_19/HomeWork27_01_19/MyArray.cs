using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork27_01_19
{
    public class MyArray
    {
        public int[] NumbersArray { get; set; }
        public int this[int index]
        {
            get
            {
                return NumbersArray[index];
            }
            set
            {
                NumbersArray[index] = (int)Math.Pow(value, Constants.SQUARE);
            }
        }
    }
}
