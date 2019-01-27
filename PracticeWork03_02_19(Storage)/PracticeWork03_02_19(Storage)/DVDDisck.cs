﻿using System;
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

        public override double GetMemoryValueInGb()
        {
            return (FreeMemory + OccupiedMemory)/Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override double GetMemoryValueInMb()
        {
            return FreeMemory + OccupiedMemory;
        }
        public override void CopyInStorageInGb(double memoryValueInGb)
        {
            FreeMemory -= memoryValueInGb*Constants.IN_GIGABYTE_MEGABYTE_COUNT;
            OccupiedMemory += memoryValueInGb*Constants.IN_GIGABYTE_MEGABYTE_COUNT;
        }
        public override void CopyInStorageInMb(double memoryValueInMb)
        {
            FreeMemory -= memoryValueInMb;
            OccupiedMemory += memoryValueInMb;
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
            return $"Name: {_name}\n" +
                   $"Model: {_model}\n" +
                   $"Type: {Type.ToString()}" +
                   $"Writing speed: {WriteSpeed}\n" +
                   $"Read speed: {ReadSpeed}\n" +
                   $"Free memory: {FreeMemory}\n" +
                   $"Occupied memory: {OccupiedMemory}";
        }

        public DVDDisck(DVDDisckType dvdType, double readSpeed, double writeSpeed)
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
            ReadSpeed = readSpeed;
            WriteSpeed = writeSpeed;
            OccupiedMemory = Constants.NULL;
        }
    }
}
