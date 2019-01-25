using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork03_02_19_Storage_
{
    public class DVDDisck : Storage
    {
        public double ReadSpeed { get; set; }
        public double WriteSpeed { get; set; }
        public DVDDisckType Type { get; set; }

        public override double GetMemoryValueInMb()
        {
            return FreeMemory + OccupiedMemory;
        }
        public override double GetMemoryValueInGb()
        {
            return (FreeMemory + OccupiedMemory) * Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override void CopyInStorageInGb(double memoryValue)
        {
            FreeMemory -= memoryValue * Constants.IN_GIGABYTE_MEGABYTE_COUNT;
            OccupiedMemory += memoryValue * Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override void CopyInStorageInMb(double memoryValue)
        {
            FreeMemory -= memoryValue;
            OccupiedMemory += memoryValue;
        }
        public override double GetFreeMemoryValueInMb()
        {
            return FreeMemory;
        }
        public override double GetFreeMemoryValueInGb()
        {
            return FreeMemory / Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override string GetFullInform()
        {
            return $"{_name}; {_model}; {Type}; {FreeMemory}; {OccupiedMemory}";
        }

        public DVDDisck(DVDDisckType dvdType)
        {
            Type = dvdType;
            if(Type == DVDDisckType.Bilateral)
            {
                FreeMemory = Constants.BILATERAL_DVDDISCK_MEMORY;
            }
            else if(Type == DVDDisckType.Unilateral)
            {
                FreeMemory = Constants.UNITARELAL_DVDDISCK_MEMORY;
            }
        }
    }
}
