using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork21_01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane[] planes = new Plane[Constants.MINIMAL_PLANES_COUNT];
        }
    }
    public partial class Plane
    {
        #region Методы
        public double CargoDumping()
        {
            double cargoWeight = _cargoWeight;
            _cargoWeight = Constants.NULL;
            return cargoWeight;
        }
        #endregion
    }
}
