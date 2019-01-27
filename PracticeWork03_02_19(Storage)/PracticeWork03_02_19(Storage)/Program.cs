using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork03_02_19_Storage_
{
    class Program
    {
        static void Main(string[] args)
        {
            double informationMemoryValueInGb = Constants.NULL;

            SetInformationMemory(ref informationMemoryValueInGb);

            double flashMemory = SetFlashMemory();
            int hddSectionCount = SetSectionCount();
            double hddSectionMemory = SetSectionMemory();
            DVDDisckType dvdDisckType = SetDVDDisckType();
            double dvdDisckWriteSpeed = SetDVDDisckWriteSpeed();
            double dvdDisckReadSpeed = SetDVDDisckReadSpeed();

            int flashCount = StorageCount(flashMemory, informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT);
            int hddCount = StorageCount(hddSectionCount*hddSectionMemory, informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT);
            int dvdCount = Constants.NULL;
            switch (dvdDisckType)
            {
                case DVDDisckType.Unilateral:
                    dvdCount = StorageCount(Constants.UNITARELAL_DVDDISCK_MEMORY, informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT);
                    break;
                case DVDDisckType.Bilateral:
                    dvdCount = StorageCount(Constants.BILATERAL_DVDDISCK_MEMORY, informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT);
                    break;
            }

            Storage[] flashStorage = new FlashMemory[flashCount];
            Storage[] hddStorage = new HDDStorage[hddCount];
            Storage[] dvdDisckStorage = new DVDDisck[dvdCount];

            StorageInitialization(flashStorage, flashMemory);
            StorageInitialization(hddStorage, hddSectionCount, hddSectionMemory);
            StorageInitialization(dvdDisckStorage, dvdDisckType, dvdDisckReadSpeed, dvdDisckWriteSpeed);

            bool isWantToCopy;

            while (true)
            {
                try
                {
                    Console.WriteLine("Хотите сделать резервную копию(y/n)");

                    string choice = Console.ReadLine().Trim();

                    if(choice == "y" || choice == "Y" || choice == "Yes" || choice == "YES")
                    {
                        isWantToCopy = true;
                        break;
                    }
                    else if (choice == "n" || choice == "N" || choice == "No" || choice == "NO")
                    {
                        isWantToCopy = false;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("Некоректный ответ");
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            if(isWantToCopy == true)
            {
                for(int i = 0; i < flashStorage.Length; i++)
                {
                    double copyMemory = informationMemoryValueInGb*Constants.IN_GIGABYTE_MEGABYTE_COUNT - (flashStorage[i] as FlashMemory).FreeMemory;
                    (flashStorage[i] as FlashMemory).CopyInStorageInMb(informationMemoryValueInGb*Constants.IN_GIGABYTE_MEGABYTE_COUNT);
                }
                for (int i = 0; i < hddStorage.Length; i++)
                {
                    double copyMemory = informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT - (hddStorage[i] as HDDStorage).FreeMemory;
                    (hddStorage[i] as HDDStorage).CopyInStorageInMb(informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT);
                }
                for (int i = 0; i < dvdDisckStorage.Length; i++)
                {
                    double copyMemory = informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT - (dvdDisckStorage[i] as DVDDisck).FreeMemory;
                    (dvdDisckStorage[i] as DVDDisck).CopyInStorageInMb(informationMemoryValueInGb * Constants.IN_GIGABYTE_MEGABYTE_COUNT);
                }
            }

            Console.WriteLine($"Общая память всех устройств\n" +
                              $"Flash: {flashMemory*flashCount}\n" +
                              $"HDD: {hddSectionCount*hddSectionMemory*hddCount}\n" +
                              $"DVDDisck: {dvdDisckStorage[Constants.FIRST_INDEX].GetMemoryValueInMb() * dvdCount}");

            Console.WriteLine($"Кол необходимых носителей\n" +
                              $"Flash: {flashCount}\n" +
                              $"HDD: {hddCount}\n" +
                              $"DVDDisck: {dvdCount}\n");

            Console.WriteLine($"Необходимое время для копирование\n" +
                              $"Flash: {CopyingTime(flashStorage[Constants.FIRST_INDEX] as FlashMemory, informationMemoryValueInGb*Constants.IN_GIGABYTE_MEGABYTE_COUNT) * flashCount}s\n"+
                              $"HDD: {CopyingTime(hddStorage[Constants.FIRST_INDEX] as HDDStorage, informationMemoryValueInGb*Constants.IN_GIGABYTE_MEGABYTE_COUNT)}s\n" +
                              $"DVDDisck: {CopyingTime(dvdDisckStorage[Constants.FIRST_INDEX] as DVDDisck, informationMemoryValueInGb*Constants.IN_GIGABYTE_MEGABYTE_COUNT)}s\n");
        }

        static void SetInformationMemory(ref double informationMemoryValueInGb)
        {
            Console.WriteLine("Каков размер ваших файлов(Гб)");

            try
            {
                if (double.TryParse(Console.ReadLine().Trim(), out informationMemoryValueInGb)) {}
                else
                {
                    throw new ArgumentException("Ввели размер файло неправильно");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                SetInformationMemory(ref informationMemoryValueInGb);
            }
        }
        static double SetFlashMemory()
        {
            try
            {
                double flashMemory;

                Console.WriteLine("Установите размер флеш памяти(Мб): ");

                if(double.TryParse(Console.ReadLine().Trim(), out flashMemory))
                {
                    return flashMemory;
                }
                else
                {
                    throw new ArgumentException("Ввели неправильно память");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetFlashMemory();
            }
        }
        static DVDDisckType SetDVDDisckType()
        {
            try
            {

                Console.WriteLine("Выберите тип диска\n" +
                                  "1-Одностороний\n" +
                                  "2-Двустороний");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine();
                        return DVDDisckType.Unilateral;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        return DVDDisckType.Bilateral;
                    default:
                        throw new ArgumentException("Нет такого типа диска");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetDVDDisckType();
            }
        }
        static double SetDVDDisckWriteSpeed()
        {
            try
            {
                double writeSpeed;

                Console.WriteLine("Установите скорость записи DVD(Мб/с): ");

                if (double.TryParse(Console.ReadLine().Trim(), out writeSpeed))
                {
                    return writeSpeed;
                }
                else
                {
                    throw new ArgumentException("Ввели неправильно скорость");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetFlashMemory();
            }
        }
        static double SetDVDDisckReadSpeed()
        {
            try
            {
                double readSpeed;

                Console.WriteLine("Установите скорость чтения DVD(Мб/с): ");

                if (double.TryParse(Console.ReadLine().Trim(), out readSpeed))
                {
                    return readSpeed;
                }
                else
                {
                    throw new ArgumentException("Ввели неправильно скорость");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetFlashMemory();
            }
        }
        static int SetSectionCount()
        {
            try
            {
                int sectionCount;

                Console.WriteLine("Введите кол разделов в диске:");

                if(int.TryParse(Console.ReadLine().Trim(), out sectionCount))
                {
                    return sectionCount;
                }
                else
                {
                    throw new ArgumentException("Ввели неправильно кол разделов в диске");
                }
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetSectionCount();
            }
        }
        static double SetSectionMemory()
        {
            try
            {
                double sectionMemory;

                Console.WriteLine("Введите размер памяти в разделе диска(Мб):");

                if (double.TryParse(Console.ReadLine().Trim(), out sectionMemory))
                {
                    return sectionMemory;
                }
                else
                {
                    throw new ArgumentException("Ввели неправильно размер памяти в разделе диска");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetSectionCount();
            }
        }

        static int StorageCount(double storageMemory, double informationMemory)
        {
            if(informationMemory / storageMemory > (int)(informationMemory / storageMemory))
            {
                return (int)(informationMemory / storageMemory) + Constants.LENTH_TO_INDEX;
            }
            else
            {
                return (int)(informationMemory / storageMemory);
            }
        }

        static double CopyingTime(FlashMemory flashMemory, double copyMemory)
        {
            return copyMemory / flashMemory.Speed;
        }
        static double CopyingTime(HDDStorage hddStorage, double copyMemory)
        {
            return copyMemory / hddStorage.Speed;
        }
        static double CopyingTime(DVDDisck dvdDisck, double copyMemory)
        {
            return copyMemory / dvdDisck.WriteSpeed + copyMemory/dvdDisck.ReadSpeed;
        }

        static void StorageInitialization(Storage[] flashStorage, double memory)
        {
            for(int i = 0; i < flashStorage.Length; i++)
            {
                flashStorage[i] = new FlashMemory(memory);
            }
        }
        static void StorageInitialization(Storage[] hddStorages, int sectionCount, double sectionMemory)
        {
            for (int i = 0; i < hddStorages.Length; i++)
            {
                hddStorages[i] = new HDDStorage(sectionCount, sectionMemory);
            }
        }
        static void StorageInitialization(Storage[] dvdDisckStorage, DVDDisckType type, double readSpeed, double writeSpeed)
        {
            for (int i = 0; i < dvdDisckStorage.Length; i++)
            {
                dvdDisckStorage[i] = new DVDDisck(type, readSpeed, writeSpeed);
            }
        }
    }
}
