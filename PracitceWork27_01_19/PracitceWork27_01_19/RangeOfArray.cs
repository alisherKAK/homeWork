using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracitceWork27_01_19
{
    public class RangeOfArray
    {
        #region Свойства
        private int _rangeStart;
        public int RangeStart
        {
            get
            {
                return _rangeStart;
            }
            set
            {
                _rangeStart = value;
                RangeEnd = Array.Length + _rangeStart - Constants.LENTH_TO_INDEX;
            }
        }
        public int RangeEnd { get; set; }
        public int[] Array { get; set; }
        public int this[int index]
        {
            get
            {
                if (index >= RangeStart && index <= RangeEnd)
                {
                    return Array[index - RangeStart];
                }
                else
                {
                    throw new IndexOutOfRangeException("Не входите в диапозон!");
                }
            }

            set
            {
                if (index >= RangeStart && index <= RangeEnd)
                {
                    Array[index - RangeStart] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Не входите в диапозон!");
                }
            }
        }
        #endregion
    }
}
