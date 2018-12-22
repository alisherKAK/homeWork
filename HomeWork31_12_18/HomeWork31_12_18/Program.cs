using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork31_12_18
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NULL = 0;
            const int ONE = 1;
            const int TEN = 10;
            const int TWO = 2;
            const int CUBE = 3;

            const int maxNumber = 100;
            const int numberOfMeterPerSantimeter = 100;
            const int daysCountInWeek = 7;

            //1
            Random randNumber = new Random();
            int firstNumber = randNumber.Next(maxNumber), secondNumber = randNumber.Next(maxNumber), thirdNumber = randNumber.Next(maxNumber);

            Console.WriteLine(firstNumber + "  " + secondNumber + "  " + thirdNumber);
            Console.WriteLine("-----------------------------");


            //2
            Console.WriteLine("5");
            Console.WriteLine("10");
            Console.WriteLine("21");
            Console.WriteLine("-----------------------------");


            //3
            int distanceInSantimeter;
            double distanceInMeter;

            Console.Write("Set distance in santimeters: ");
            distanceInSantimeter = int.Parse(Console.ReadLine());
            distanceInMeter = (double)distanceInSantimeter / numberOfMeterPerSantimeter;
            Console.WriteLine("In " + distanceInSantimeter + " santimeters " + distanceInMeter + " meters");
            Console.WriteLine("-----------------------------");


            //4
            int daysCount = 234, fullWeeks;
            fullWeeks = daysCount / daysCountInWeek;
            Console.WriteLine("In " + daysCount + " days " + fullWeeks + " full week");
            Console.WriteLine("-----------------------------");


            //5
            int twoDigitsNumber, sumOfDigits, multiplyOfDigits, firstDigit, secondDigit, countOfUnit = NULL;

            Console.Write("Set tow digit number: ");
            twoDigitsNumber = int.Parse(Console.ReadLine());

            firstDigit = twoDigitsNumber % TEN;
            twoDigitsNumber /= TEN;
            secondDigit = twoDigitsNumber % TEN;
            sumOfDigits = firstDigit;
            sumOfDigits += secondDigit;
            multiplyOfDigits = firstDigit;
            multiplyOfDigits *= secondDigit;

            if (firstDigit == ONE) countOfUnit++;
            if (secondDigit == ONE) countOfUnit++;

            Console.WriteLine("Count of digits: 2");
            Console.WriteLine("Count of units: " + countOfUnit);
            Console.WriteLine("Sum of digits: " + sumOfDigits);
            Console.WriteLine("Multipy of digits: " + multiplyOfDigits);
            Console.WriteLine("-----------------------------");


            //6
            Console.WriteLine(true || false);
            Console.WriteLine(true && false);
            Console.WriteLine(false || false);
            Console.WriteLine("-----------------------------");


            //7
            double circleRadius, sideOfASquare;

            Console.Write("Set circle radius: ");
            circleRadius = double.Parse(Console.ReadLine());
            Console.Write("Set side of a square: ");
            sideOfASquare = double.Parse(Console.ReadLine());

            if ((Math.PI * Math.Pow(circleRadius, TWO)) > (Math.Pow(sideOfASquare, 2)))
            {
                Console.WriteLine("Circle square bigger than square area");
            }
            else if ((Math.PI * Math.Pow(circleRadius, TWO)) < (Math.Pow(sideOfASquare, 2)))
            {
                Console.WriteLine("Square area bigger than circle square");
            }
            else
            {
                Console.WriteLine("Square area and circle square equal");
            }
            Console.WriteLine("-----------------------------");


            //8
            double firstObjectVolume, secondObjectVolume;
            double firstObjectMass, secondObjectMass;

            Console.Write("Set first object mass: ");
            firstObjectMass = double.Parse(Console.ReadLine());
            Console.Write("Set first object volume: ");
            firstObjectVolume = double.Parse(Console.ReadLine());

            Console.Write("Set second object mass: ");
            secondObjectMass = double.Parse(Console.ReadLine());
            Console.Write("Set second object volume: ");
            secondObjectVolume = double.Parse(Console.ReadLine());

            if ((firstObjectMass / firstObjectVolume) > (secondObjectMass / secondObjectVolume))
            {
                Console.WriteLine("First object denser then second object");
            }
            else if ((firstObjectMass / firstObjectVolume) < (secondObjectMass / secondObjectVolume))
            {
                Console.WriteLine("Second object denser then first object");
            }
            else
            {
                Console.WriteLine("First object density and second object density equal");
            }
            Console.WriteLine("-----------------------------");


            //9
            double firstElectricalCircuitResistance, firstElectricalCircuitVoltage;
            double secondElectricalCircuitResistance, secondElectricalCircuitVoltage;

            Console.Write("Set first electrical circuit voltage: ");
            firstElectricalCircuitVoltage = double.Parse(Console.ReadLine());
            Console.Write("Set first electrical circuit resistance: ");
            firstElectricalCircuitResistance = double.Parse(Console.ReadLine());

            Console.Write("Set second electrical circuit voltage: ");
            secondElectricalCircuitVoltage = double.Parse(Console.ReadLine());
            Console.Write("Set second electrical circuit resistance: ");
            secondElectricalCircuitResistance = double.Parse(Console.ReadLine());

            if ((firstElectricalCircuitVoltage / firstElectricalCircuitResistance) > (secondElectricalCircuitVoltage / secondElectricalCircuitResistance))
            {
                Console.WriteLine("First electrical circuit amperage bigger than second electrical circuit");
            }
            else if ((firstElectricalCircuitVoltage / firstElectricalCircuitResistance) < (secondElectricalCircuitVoltage / secondElectricalCircuitResistance))
            {
                Console.WriteLine("Second electrical circuit amperage bigger than first electrical circuit");
            }
            else
            {
                Console.WriteLine("First electrical circuit amperage and second electrical circuit amperage equal");
            }
            Console.WriteLine("-----------------------------");


            //10
            int firstBorder = 20, secondBorder = 35;

            //a.
            for (int i = firstBorder; i <= secondBorder; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //b.
            firstBorder = 10;
            while (true)
            {
                Console.Write("Set second border: ");
                secondBorder = int.Parse(Console.ReadLine());
                if (secondBorder > firstBorder) break;
            }

            for (int i = firstBorder; i <= secondBorder; i++)
            {
                Console.WriteLine(Math.Pow(i, TWO));
            }
            Console.WriteLine();

            //c.
            secondBorder = 50;
            while (true)
            {
                Console.Write("Set first border: ");
                firstBorder = int.Parse(Console.ReadLine());
                if (secondBorder > firstBorder) break;
            }

            for (int i = firstBorder; i <= secondBorder; i++)
            {
                Console.WriteLine(Math.Pow(i, CUBE));
            }
            Console.WriteLine();

            //d.while (true)
            while (true)
            {
                Console.Write("Set first border: ");
                firstBorder = int.Parse(Console.ReadLine());
                Console.Write("Set second border: ");
                secondBorder = int.Parse(Console.ReadLine());
                if (secondBorder > firstBorder) break;
            }

            for (int i = firstBorder; i <= secondBorder; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
