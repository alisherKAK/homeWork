using HomeWork03_05_19.ConstantsAndEnums;
using System;
using System.Linq;

namespace HomeWork03_05_19.Services
{
    public static class SetInformations
    {
        public static string SetLogin()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите логин:");

                    string login = Console.ReadLine().Trim();

                    if (login.Where(letter => (letter >= 'a' && letter <= 'z') ||
                                              (letter >= 'A' && letter <= 'Z') ||
                                              (letter >= '0' && letter <= '9') || letter == '_').ToList().Count == login.Length)
                    {
                        return login;
                    }

                    throw new ArgumentException("Неправильно ввели логин");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetPassword()
        {
            try
            {
                Console.WriteLine("Password: ");

                string password = "";

                ConsoleKeyInfo key;

                do
                {
                    key = System.Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        Console.Write("*");
                        password += key.KeyChar;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (!string.IsNullOrEmpty(password))
                        {
                            // remove one character from the list of password characters
                            password = password.Substring(0, password.Length - 1);
                            // get the location of the cursor
                            int pos = System.Console.CursorLeft;
                            // move the cursor to the left by one character
                            System.Console.SetCursorPosition(pos - 1, System.Console.CursorTop);
                            // replace it with space
                            Console.Write(" ");
                            // move the cursor to the left by one character again
                            System.Console.SetCursorPosition(pos - 1, System.Console.CursorTop);
                        }
                    }

                } while (key.Key != ConsoleKey.Enter);

                Console.WriteLine("");

                password = password.Trim();

                if (password.Length < Constants.PASSWORD_MINIMAL_LENGTH)
                {
                    throw new ArgumentException("Password был введен неверно");
                }

                if (password.Where(letter => letter == ' ' || letter == '\t' || letter == '\n').ToList().Count != Constants.NULL)
                {
                    throw new ArgumentException("Password был введен неверно");
                }

                return password;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return SetPassword();
            }
        }

        public static double SetPrice()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите цену:");

                    double price;

                    if(double.TryParse(Console.ReadLine().Trim(), out price))
                    {
                        return price;
                    }

                    throw new ArgumentException("Цена была введена неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static DateTime SetProducedDate()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите дату производства(dd.mm.yyyy):");

                    DateTime producedDate = Convert.ToDateTime(Console.ReadLine().Trim());

                    return producedDate;
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static DateTime SetExpirationDate(DateTime producedDate)
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите дату окончания срока годности(dd.mm.yyyy):");

                    DateTime expirationDate = Convert.ToDateTime(Console.ReadLine().Trim());

                    if(expirationDate >= producedDate)
                    {
                        return expirationDate;
                    }

                    throw new ArgumentException("Дату окончания срока годности не может быть раньше чем дата производства");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetProductName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя продукта:");

                    string productName = Console.ReadLine().Trim();

                    if (productName.Any(letter => (letter >= 'a' && letter <= 'z') ||
                                                  (letter >= 'A' && letter <= 'Z')))
                    {
                        return productName;
                    }

                    throw new ArgumentException("Имя продукта введена неврено");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
