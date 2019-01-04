using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork27_12_18
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LENTH_TO_INDEX = 1;
            const int HALF = 2;
            const int EVEN_NUMBER = 2;
            const int NULL = 0;
            const int NULL_FOR_MULTIPLY = 1;
            const int FIRST_ELEMENT_IN_MASS = 0;
            const int MAX_RANDOM_NUMBER = 100;
            const int MIN_RANDOM_NUMBER = -100;
            const int FIRST_MAS_MAX_SIZE = 5;
            const int SECOND_MAS_MAX_ROW_SIZE = 3;
            const int SECOND_MAS_MAX_COLUMN_SIZE = 4;
            const int ARRAY_MAX_NUMBER = 20;
            Random randomNumber = new Random();

            //1
            int[] integerNumbers = new int[FIRST_MAS_MAX_SIZE];
            double[,] doubleNumbers = new double[SECOND_MAS_MAX_ROW_SIZE, SECOND_MAS_MAX_COLUMN_SIZE];

            for(int i = 0; i < FIRST_MAS_MAX_SIZE; i++)
            {
                Console.Write($"Set {i + LENTH_TO_INDEX} number: ");
                integerNumbers[i] = int.Parse(Console.ReadLine());
            }

            for(int i = 0; i < SECOND_MAS_MAX_ROW_SIZE; i++)
            {
                for(int j = 0; j < SECOND_MAS_MAX_COLUMN_SIZE; j++)
                {
                    doubleNumbers[i, j] = randomNumber.Next(MAX_RANDOM_NUMBER);
                }
            }
            Console.WriteLine("-----------------------------");


            Console.WriteLine("1 Demension massive");
            for(int i = 0; i < FIRST_MAS_MAX_SIZE; i++)
            {
                Console.Write(integerNumbers[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------");


            Console.WriteLine("2 Demension massive");
            for(int i = 0; i < SECOND_MAS_MAX_ROW_SIZE; i++)
            {
                for(int j = 0; j < SECOND_MAS_MAX_COLUMN_SIZE; j++)
                {
                    Console.Write(doubleNumbers[i, j] + " ");
                }
                Console.WriteLine();
            }

            int minimalNumberInIntegerArray = integerNumbers[FIRST_ELEMENT_IN_MASS], maximalNumberInIntegerArray = integerNumbers[FIRST_ELEMENT_IN_MASS];
            double minimalNumberInDoubleArray = doubleNumbers[FIRST_ELEMENT_IN_MASS, FIRST_ELEMENT_IN_MASS], maximalNumberInDoubleArray = doubleNumbers[FIRST_ELEMENT_IN_MASS, FIRST_ELEMENT_IN_MASS];
            int sumNumberInIntegerArray = NULL, multiplyNumberInIntegerArray = NULL_FOR_MULTIPLY, sumOfEvenElementsInIntegerArray = NULL;
            double sumNumberInDoubleArray = NULL, multiplyNumberInDoubleArray = NULL_FOR_MULTIPLY, sumOfNotEvenColumnInDoubleArray = NULL;

            for (int i = 0; i < integerNumbers.Length; i++)
            {
                if(i % EVEN_NUMBER == NULL)
                {
                    sumOfEvenElementsInIntegerArray += integerNumbers[i];
                }
                if(integerNumbers[i] < minimalNumberInIntegerArray)
                {
                    minimalNumberInIntegerArray = integerNumbers[i];
                }
                if(integerNumbers[i] > maximalNumberInIntegerArray)
                {
                    maximalNumberInIntegerArray = integerNumbers[i];
                }
                sumNumberInIntegerArray += integerNumbers[i];
                multiplyNumberInIntegerArray *= integerNumbers[i];
            }

            for(int i = 0; i < SECOND_MAS_MAX_ROW_SIZE; i++)
            {
                for(int j = 0; j < SECOND_MAS_MAX_COLUMN_SIZE; j++)
                { 
                    if(j % EVEN_NUMBER != NULL)
                    {
                        sumOfNotEvenColumnInDoubleArray += doubleNumbers[i, j];
                    }
                    if(doubleNumbers[i, j] < minimalNumberInDoubleArray)
                    {
                        minimalNumberInDoubleArray = doubleNumbers[i, j];
                    }
                    if(doubleNumbers[i, j] > maximalNumberInDoubleArray)
                    {
                        maximalNumberInDoubleArray = doubleNumbers[i, j];
                    }
                    sumNumberInDoubleArray += doubleNumbers[i, j];
                    multiplyNumberInDoubleArray *= doubleNumbers[i, j];
                }
            }
            Console.WriteLine("-----------------------------");

            Console.WriteLine($"Minimal number in integer array: {minimalNumberInIntegerArray}");
            Console.WriteLine($"Maximal number in integer array: {maximalNumberInIntegerArray}");
            Console.WriteLine($"Sum of all elements in integer array: {sumNumberInIntegerArray}");
            Console.WriteLine($"Multiply of all elements in integer array: {multiplyNumberInIntegerArray}");
            Console.WriteLine($"Sum of even elements in integer array: {sumOfEvenElementsInIntegerArray}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Minimal number in double array: {minimalNumberInDoubleArray}");
            Console.WriteLine($"Maximal number in double array: {maximalNumberInDoubleArray}");
            Console.WriteLine($"Sum of all elements in double array: {sumNumberInDoubleArray}");
            Console.WriteLine($"Multiply of all elements in double array: {multiplyNumberInDoubleArray}");
            Console.WriteLine($"Sum of not even column elements in integer array: {sumOfNotEvenColumnInDoubleArray}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //2
            int lenthOfFirstArray, lenthOfSecondArray, lenthOfThirdArray = NULL;

            Console.Write("Set first array lenth: ");
            lenthOfFirstArray = int.Parse(Console.ReadLine());
            Console.Write("Set second array lenth: ");
            lenthOfSecondArray = int.Parse(Console.ReadLine());

            int[] firstArray = new int[lenthOfFirstArray], secondArray = new int[lenthOfSecondArray];

            for(int i = 0; i < firstArray.Length; i++)
            {
                firstArray[i] = randomNumber.Next(ARRAY_MAX_NUMBER);
            }
            for (int i = 0; i < secondArray.Length; i++)
            {
                secondArray[i] = randomNumber.Next(ARRAY_MAX_NUMBER);
            }

            for(int i = 0; i < firstArray.Length; i++)
            {
                Console.Write(firstArray[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < secondArray.Length; i++)
            {
                Console.Write(secondArray[i] + " ");
            }
            Console.WriteLine();

            bool hasAlready;
            for(int i = 0; i < firstArray.Length; i++)
            {
                hasAlready = false;
                for(int j = 0; j < i; j++)
                {
                    if(firstArray[i] == firstArray[j])
                    {
                        hasAlready = true;
                    }
                }
                if(hasAlready == false)
                {
                    for(int a = 0; a < secondArray.Length; a++)
                    {
                        if(firstArray[i] == secondArray[a])
                        {
                            ++lenthOfThirdArray;
                            break;
                        }
                    }
                }
            }

            int[] thirdArray = new int[lenthOfThirdArray];
            for (int i = 0, b = 0; i < firstArray.Length; i++)
            {
                hasAlready = false;
                for (int j = 0; j < i; j++)
                {
                    if (firstArray[i] == firstArray[j])
                    {
                        hasAlready = true;
                    }
                }
                if (hasAlready == false)
                {
                    for (int a = 0; a < secondArray.Length; a++)
                    {
                        if (firstArray[i] == secondArray[a])
                        {
                            thirdArray[b] = firstArray[i];
                            ++b;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Third array lenth: {lenthOfThirdArray}");
            for(int i = 0; i < thirdArray.Length; i++)
            {
                Console.Write(thirdArray[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //3
            Console.Write("Write some string: ");
            string insertString = Console.ReadLine();
            bool isPalendrom = false;
            
            for(int i = 0, j = insertString.Length - 1; i < insertString.Length / HALF; i++, j--)
            {
                if(insertString[i] == insertString[j])
                {
                    isPalendrom = true;
                }
                else
                {
                    isPalendrom = false;
                    break;
                }
            }

            if (isPalendrom == true)
            {
                Console.WriteLine("This string palendrom!");
            }
            else
            {
                Console.WriteLine("This string not palendrom!");
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //4
            Console.Write("Write some sentance: ");
            string insertSentence = Console.ReadLine();

            insertSentence = insertSentence.Trim();

            int wordCount = (insertSentence.Split(' ')).Length;

            Console.WriteLine($"{wordCount} word in this sentence!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //5
            const int TWO_DIMENSION_ROW_AND_COLUMN_COUNT = 5;

            int[,] twoDemensionArray = new int[TWO_DIMENSION_ROW_AND_COLUMN_COUNT, TWO_DIMENSION_ROW_AND_COLUMN_COUNT];
            int minimalElementInArray = twoDemensionArray[NULL, NULL], minimalElementXCoordinate = NULL, minimalElementYCoordinate = NULL;
            int maximalElementInArray = twoDemensionArray[NULL, NULL], maximalElementXCoordinate = NULL, maximalElementYCoordinate = NULL;
            int sumElementsBetweenMinimalAndMaximalElements = NULL;

            for(int i = 0; i < TWO_DIMENSION_ROW_AND_COLUMN_COUNT; i++)
            {
                for(int j = 0; j  < TWO_DIMENSION_ROW_AND_COLUMN_COUNT; j++)
                {
                    twoDemensionArray[i, j] = randomNumber.Next(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER);
                    if (twoDemensionArray[i, j] < minimalElementInArray)
                    {
                        minimalElementInArray = twoDemensionArray[i, j];
                        minimalElementXCoordinate = j;
                        minimalElementYCoordinate = i;
                    }
                    if (twoDemensionArray[i, j] > maximalElementInArray)
                    {
                        maximalElementInArray = twoDemensionArray[i, j];
                        maximalElementXCoordinate = j;
                        maximalElementYCoordinate = i;
                    }
                }
            }

            for (int i = 0; i < TWO_DIMENSION_ROW_AND_COLUMN_COUNT; i++)
            {
                for (int j = 0; j < TWO_DIMENSION_ROW_AND_COLUMN_COUNT; j++)
                {
                    Console.Write(twoDemensionArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            if (minimalElementYCoordinate < maximalElementYCoordinate)
            {
                for(int i = minimalElementYCoordinate; i <= maximalElementYCoordinate; i++)
                {
                    for(int j = 0; j < TWO_DIMENSION_ROW_AND_COLUMN_COUNT; j++)
                    {
                        if(i == minimalElementYCoordinate && j < minimalElementXCoordinate)
                        {
                            continue;
                        }
                        if(i == maximalElementYCoordinate && j > maximalElementXCoordinate)
                        {
                            continue;
                        }
                        sumElementsBetweenMinimalAndMaximalElements += twoDemensionArray[i, j];
                    }
                }
            }
            else
            {
                for (int i = maximalElementYCoordinate; i <= minimalElementYCoordinate; i++)
                {
                    for (int j = 0; j < TWO_DIMENSION_ROW_AND_COLUMN_COUNT; j++)
                    {
                        if (i == maximalElementYCoordinate && j < maximalElementXCoordinate)
                        {
                            continue;
                        }
                        if (i == minimalElementYCoordinate && j > minimalElementXCoordinate)
                        {
                            continue;
                        }
                        sumElementsBetweenMinimalAndMaximalElements += twoDemensionArray[i, j];
                    }
                }
            }
            

            Console.WriteLine($"Minimal element: {minimalElementInArray}({minimalElementXCoordinate},{minimalElementYCoordinate})");
            Console.WriteLine($"Maximal element: {maximalElementInArray}({maximalElementXCoordinate},{maximalElementYCoordinate})");
            Console.WriteLine($"Sum of the elements between minimal and maximal elements: {sumElementsBetweenMinimalAndMaximalElements}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
