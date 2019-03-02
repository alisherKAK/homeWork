﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticeWork10_03_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Введите путь до файла:");

            string path = Console.ReadLine().Trim();

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                int[] buffer = new int[fileStream.Length];

                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = fileStream.ReadByte();
                }

                int[] symbols = new int[Constants.ACII_SYMBOLS_COUNT];

                for (int i = 0; i < symbols.Length; i++)
                {
                    symbols[i] = Constants.NULL;
                }

                for (int i = 0; i < buffer.Length; i++)
                {
                    ++symbols[buffer[i]];
                }

                for (int i = 0; i < symbols.Length; i++)
                {
                    Console.WriteLine($"{i.ToString()} count: {symbols[i]}");
                }
            }


            //2
            path = "";

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady == true)
                {
                    Console.WriteLine($"{i}.{drives[i].Name}");
                }
            }

            int number = SetDrive(drives);

            path = drives[number].Name;

            Console.WriteLine($"Выбран диск {path}");

            foreach (var directory in drives[number].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine($"Папка {directory.Name}");
            }

            Console.WriteLine("Напишите название папки котоую хотите создать:");
            var directoryName = Console.ReadLine();
            path += directoryName;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Console.WriteLine("Напишите название файла который хотите создать:");
            var fileName = Console.ReadLine();
            path += @"\" + fileName;

            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
            }

            Console.WriteLine("Введите свое имя:");
            string userFirstName = Console.ReadLine().Trim();

            Console.WriteLine("Введите свою фамилию:");
            string userLastName = Console.ReadLine().Trim();

            Console.WriteLine("Введите свой возраст:");
            string userAge = SetUserAge().ToString();

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(userFirstName);
                streamWriter.WriteLine(userLastName);
                streamWriter.WriteLine(userAge);
            }
        }
        static int SetDrive(DriveInfo[] drives)
        {
            try
            {
                int number;

                Console.WriteLine("Выберите диск в котором хотите создать файл написав его порядковый номер:");

                if(int.TryParse(Console.ReadLine(), out number))
                {
                    if(number < drives.Length && number >= Constants.NULL)
                    {
                        return number;
                    }
                }

                throw new ArgumentException("Нету диска под таким номером");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                return SetDrive(drives);
            }
        }
        static int SetUserAge()
        {
            try
            {
                int age;

                Console.WriteLine("Введите свой возраст:");
                
                if(int.TryParse(Console.ReadLine().Trim(), out age))
                {
                    return age;
                }

                throw new ArgumentException("Неправильно ввели возраст");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetUserAge();
            }
        }
    }
}
