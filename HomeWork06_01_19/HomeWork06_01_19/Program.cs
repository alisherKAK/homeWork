using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork06_01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PLUS_ONE_ZERO_BEHIND_NUMBER = 10;
            const int PLUS_ONE = 1;
            const int DIFFERENCE_BETWEEN_UPPER_AND_LOWER_CASE = 32;
            const int CONVERT_INDEX = 1;
            const int HALF = 2;
            const int TICKET_LENGTH = 6;
            const int NULL = 0;
            const int DOT_CODE = 46;

            //1
            int spaceKeyCount = NULL;
            Console.Write("Write some string: ");
            while (true)
            {
                int insertKeyCode = Console.Read();
                if(insertKeyCode == DOT_CODE)
                {
                    break;
                }
                if(insertKeyCode == (int)ConsoleKey.Spacebar)
                {
                    ++spaceKeyCount;
                }
            }

            Console.ReadLine();
            Console.WriteLine($"Space count: {spaceKeyCount}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //2
            int[] ticketNumbers = new int[TICKET_LENGTH];
            bool isLucky = false;

            Console.Write("Write ticket numbers: ");

            for(int i = 0; i < TICKET_LENGTH; i++)
            {
                ticketNumbers[i] = Console.Read() - (int)ConsoleKey.D0;
            }
            Console.ReadLine();

            for(int i = 0, j = TICKET_LENGTH - CONVERT_INDEX, firstHalfSum = 0, secondHalfSum = 0; i < TICKET_LENGTH / HALF; i++, j--)
            {
                firstHalfSum += ticketNumbers[i];
                secondHalfSum += ticketNumbers[j];
                if(i == HALF)
                {
                    if (firstHalfSum == secondHalfSum)
                    {
                        isLucky = true;
                    }
                }
            }

            if(isLucky == true)
            {
                Console.WriteLine("This ticket lucky");
            }
            else
            {
                Console.WriteLine("This ticket not lucky");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //3
            string inputString;

            Console.Write("Write some string: ");
            inputString = Console.ReadLine();
            char[] changedString = new char[inputString.Length];

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] >= 'a' && inputString[i] <= 'z')
                {
                    changedString[i] = (char)((int)inputString[i] - DIFFERENCE_BETWEEN_UPPER_AND_LOWER_CASE);
                }
                else if (inputString[i] >= 'A' && inputString[i] <= 'Z')
                {
                    changedString[i] = (char)((int)inputString[i] + DIFFERENCE_BETWEEN_UPPER_AND_LOWER_CASE);
                }
                else
                {
                    changedString[i] = inputString[i];
                }
            }
            Console.WriteLine();

            for (int i = 0; i < changedString.Length; i++)
            {
                Console.Write(changedString[i]);
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //4
            uint firstNumber, secondNumber;
            while (true)
            {
                Console.Write("Set first number: ");
                firstNumber = uint.Parse(Console.ReadLine());
                Console.Write("Set second number: ");
                secondNumber = uint.Parse(Console.ReadLine());
                Console.WriteLine();

                if(firstNumber < secondNumber)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Second number must bigger than first number!");
                }
            }
            uint[][] numbers = new uint[secondNumber - firstNumber + PLUS_ONE][];

            for(uint i = 0; i <= secondNumber - firstNumber; i++)
            {
                numbers[i] = new uint[firstNumber + i];
            }

            for(uint i = 0; i <= secondNumber - firstNumber; i++)
            {
                for(uint j = 0; j < numbers[i].Length; j++)
                {
                    numbers[i][j] = i + firstNumber;
                    Console.Write(numbers[i][j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //5
            string inputNumber;

            Console.Write("Write some number: ");
            inputNumber = Console.ReadLine();

            int number = NULL;

            for(int i = inputNumber.Length - CONVERT_INDEX ; i >= NULL; i--)
            {
                number *= PLUS_ONE_ZERO_BEHIND_NUMBER;
                number += inputNumber[i] - (int)ConsoleKey.D0;
            }
            Console.WriteLine(number);
            Console.WriteLine("-----------------------------");

            Console.ReadLine();
        }
    }
}
