using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork01_02_19
{
    public class Rectangle
    {
        public int Lenth { get; set; }
        public int Width { get; set; }

        public static bool operator==(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            if(firstRectangle.Lenth == secondRectangle.Lenth && firstRectangle.Width == secondRectangle.Width)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            return !(firstRectangle == secondRectangle);
        }

    }
}
