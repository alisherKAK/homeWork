﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPracticeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int square = 2;
            int CountSantimetersInOneMeter = 100;
            int CountDaysInOneWeek = 7;
            const int TEN = 10;
            const int HUNDRED = 100;
            const int NULL = 0;
            const int ONE = 1;

            //1
            double x;
            int aKoficent = 7, bKoficent = 3, cKoficent = 4;
            Console.Write("Введите значение x для функций y = 7x^2 - 3x + 4: ");
            x = double.Parse(Console.ReadLine());
            double result = aKoficent * Math.Pow(x, square) - bKoficent * x + cKoficent;
            Console.WriteLine("y = " + result);
            Console.WriteLine();

            //2
            double radiusCircle, lenghtCircle, squareCircle;
            Console.Write("Введите значение радиуса окружности: ");
            radiusCircle = double.Parse(Console.ReadLine());
            lenghtCircle = square * Math.PI * radiusCircle;
            squareCircle = Math.Pow(radiusCircle, square) * Math.PI;
            Console.WriteLine("Circle lenght: " + lenghtCircle);
            Console.WriteLine("Square lenght: " + squareCircle);
            Console.WriteLine();

            //3
            double santimeter, meter;
            Console.Write("Введите длину(см): ");
            santimeter = double.Parse(Console.ReadLine());
            meter = santimeter / CountSantimetersInOneMeter;
            Console.WriteLine("Эта дллина в метрах: " + meter);
            Console.WriteLine();

            //4
            int countOfDate = 234;
            int fullWeek = countOfDate / CountDaysInOneWeek;
            Console.WriteLine(fullWeek + " недель в 234 днях");
            Console.WriteLine();

            //5
            int number, countOfDigits = NULL, countOfUnits = NULL, sumOfDigits = NULL, multiplyOfDigits = ONE;
            Console.Write("Введите любое число: ");
            number = int.Parse(Console.ReadLine());
            while (number != NULL)
            {
                int digit = number % TEN;
                number /= TEN;
                if (digit == ONE)
                {
                    countOfUnits++;
                }
                sumOfDigits += digit;
                multiplyOfDigits *= digit;
                countOfDigits++;
            }
            Console.WriteLine("Count of digits: " + countOfDigits);
            Console.WriteLine("Count of units: " + countOfUnits);
            Console.WriteLine("Sum of digits: " + sumOfDigits);
            Console.WriteLine("Multiply of digits: " + multiplyOfDigits);
            Console.WriteLine();

            //6
            int fourDigitsNumber, sumOfDigitsOfFoutNumberDigits = NULL, multiplyOfDigitsOfFoutNumberDigits = ONE;
            Console.Write("Введите четырехзначное число: ");
            fourDigitsNumber = int.Parse(Console.ReadLine());
            while (fourDigitsNumber != NULL)
            {
                int digit = fourDigitsNumber % TEN;
                fourDigitsNumber /= TEN;
                sumOfDigitsOfFoutNumberDigits += digit;
                multiplyOfDigitsOfFoutNumberDigits *= digit;
            }
            Console.WriteLine("Sum of digits: " + sumOfDigitsOfFoutNumberDigits);
            Console.WriteLine("Multiply of digits: " + multiplyOfDigitsOfFoutNumberDigits);
            Console.WriteLine();

            //7
            int finalNumber = 456, searchingNumber;
            int firstDigit = finalNumber % TEN;
            finalNumber /= TEN;
            int secondDigit = finalNumber % TEN;
            finalNumber /= TEN;
            int thirdDigit = finalNumber % TEN;
            finalNumber /= TEN;
            searchingNumber = secondDigit + firstDigit * TEN + thirdDigit * HUNDRED;
            Console.WriteLine("Searching Number: " + searchingNumber);
            Console.WriteLine();

            //8

            //a.
            Console.WriteLine(!true && !true);
            Console.WriteLine(!false && !false);
            Console.WriteLine(!true && !false);
            Console.WriteLine(!false && !true);
            Console.WriteLine();

            //b.
            Console.WriteLine(true || (!true && true));
            Console.WriteLine(true || (!true && false));
            Console.WriteLine(false || (!false && false));
            Console.WriteLine(false || (!false && true));
            Console.WriteLine();

            //c.
            Console.WriteLine((!true && true) || true);
            Console.WriteLine((!false && true) || true);
            Console.WriteLine((!false && false) || false);
            Console.WriteLine((!false && true) || true);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}