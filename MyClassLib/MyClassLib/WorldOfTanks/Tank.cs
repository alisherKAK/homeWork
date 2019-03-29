using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib.WorldOfTanks
{
    public class Tank
    {
        public TanksName TankName { get; set; }
        private int _ammunitionLevel;
        public string AmmunitionLevel
        {
            get
            {
                return _ammunitionLevel.ToString();
            }
            set
            {
                if (_ammunitionLevel >= Constants.MINIMAL_PERCENT && _ammunitionLevel <= Constants.MAXIMAL_PERCENT)
                {
                    int result;
                    if (int.TryParse(value, out result))
                    {
                        _ammunitionLevel = result;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        private int _armorLevel;
        public string ArmorLevel
        {
            get
            {
                return _armorLevel.ToString();
            }
            set
            {
                if (_armorLevel >= Constants.MINIMAL_PERCENT && _armorLevel <= Constants.MAXIMAL_PERCENT)
                {
                    int result;
                    if (int.TryParse(value, out result))
                    {
                        _armorLevel = result;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        private int _maneuverabilityLevel;
        public string ManeuverabilityLevel
        {
            get
            {
                return _maneuverabilityLevel.ToString();
            }
            set
            {
                if (_maneuverabilityLevel >= Constants.MINIMAL_PERCENT && _maneuverabilityLevel <= Constants.MAXIMAL_PERCENT)
                {
                    int result;
                    if (int.TryParse(value, out result))
                    {
                        _maneuverabilityLevel = result;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Tank(){}
        public Tank(TanksName tanksName)
        {
            Random randNumber = new Random();

            TankName = tanksName;
            _ammunitionLevel = randNumber.Next(Constants.MINIMAL_PERCENT, Constants.MAXIMAL_PERCENT);
            _armorLevel = randNumber.Next(Constants.MINIMAL_PERCENT, Constants.MAXIMAL_PERCENT);
            _maneuverabilityLevel = randNumber.Next(Constants.MINIMAL_PERCENT, Constants.MAXIMAL_PERCENT);
        }
        public Tank(TanksName tanksName, int ammunitionLevel, int armorLevel, int maneuverabilityLevel)
        {
            TankName = tanksName;
            _ammunitionLevel = ammunitionLevel;
            _armorLevel = armorLevel;
            _maneuverabilityLevel = maneuverabilityLevel;
        }

        public static bool operator ^(Tank firstTank, Tank secondTank)
        {
            int advantageCount = Constants.NULL;

            if(firstTank._ammunitionLevel > secondTank._ammunitionLevel)
            {
                ++advantageCount;
            }
            if (firstTank._armorLevel > secondTank._armorLevel)
            {
                ++advantageCount;
            }
            if (firstTank._maneuverabilityLevel > secondTank._maneuverabilityLevel)
            {
                ++advantageCount;
            }

            if(advantageCount >= Constants.MINIMAL_ADVANTAGE_COUNT_TO_WIN)
            {
                return true;
            }
            return false;
        }
    }
}
