using HomeWork29_04_19.ConstantsAndEnums;
using System;
using System.Linq;

namespace HomeWork29_04_19.Services
{
    public static class SetInformation
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

        public static string SetName()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите имя:");

                    string name = Console.ReadLine().Trim();

                    if (name.Where(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')).ToList().Count == name.Length)
                    {
                        return name;
                    }

                    throw new ArgumentException("Имя было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetSurname()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите фамилию:");

                    string surname = Console.ReadLine().Trim();

                    if (surname.Where(letter => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z')).ToList().Count == surname.Length)
                    {
                        return surname;
                    }

                    throw new ArgumentException("Фамилия было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static string SetEmail()
        {
            try
            {
                Console.WriteLine("Email: ");

                string email = Console.ReadLine().Trim();

                if (email == "" || !email.Contains('@'))
                {
                    throw new ArgumentException("Email был введен неверно");
                }

                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == ' ')
                    {
                        throw new ArgumentException("Email был введен неверно");
                    }
                }

                if (email.Split('@')[Constants.SECOND_ELEMENT].Split('.').Length == Constants.CHECK_EMAIL_NUMBER && email.Split('@')[Constants.FIRST_ELEMENT] != "")
                {
                    return email;
                }

                throw new ArgumentException("Email был введен неверно");
            }
            catch (ArgumentException excepton)
            {
                Console.WriteLine(excepton.Message);

                return SetEmail();
            }
        }
    }
}
