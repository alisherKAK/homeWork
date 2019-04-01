using Hotel.Models;
using Hotel.Sevices;
using System;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
        }
        static int Chose()
        {
            try
            {
                Console.WriteLine("1) Вход\n" +
                                  "2) Регистрация\n" +
                                  "3) Выход");

                int chose;

                if(int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    return chose;
                }

                throw new ArgumentException("Выбор сделан неверно");
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return Chose();
            }
        }
        static User Registration()
        {
            User user = new User
            {
                Login = SetInformation.SetLogin(),
                Password = SetInformation.SetPassword(),
                Email = SetInformation.SetEmail(),
                Phone = SetInformation.SetPhoneNumber()
            };

            string code = CodeGenerator.Code;

            TelegramBot telegramBot = new TelegramBot();
            telegramBot.Open();
            CheckCode(code);
            telegramBot.Close();
            return user;
        }
        static void CheckCode(string code)
        {
            try
            {
                Console.WriteLine("Введите полученный код: ");
                if(Console.ReadLine().Trim() == code)
                {
                    return;
                }

                throw new ArgumentException("Неверный код ");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                CheckCode(code);
            }
        }
    }
}
