﻿using Hotel.DataAccess;
using Hotel.Models;
using Hotel.Services.Abstract;
using Hotel.Sevices;
using System;
using System.Diagnostics;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadLine();
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


            ISender sender = GetSeneder.GetSender(Sender.TelegramSender);
            sender.Open();
            sender.Send("Напишите боту 'Get code' чтобы плучить код");
            CheckCode();
            sender.Close();
            return user;
        }
        static void CheckCode()
        {
            try
            {
                Console.WriteLine("Введите полученный код: ");
                if(Console.ReadLine().Trim() == CodeGenerator.Code)
                {
                    return;
                }

                throw new ArgumentException("Неверный код ");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                CheckCode();
            }
        }
        static bool IsUserHave(User newUser)
        {
            using (TableDataService<User> tableService = new TableDataService<User>())
            {
                var data = tableService.GetAll();

                foreach (User user in data)
                {
                    if (user.Login == newUser.Login || user.Email == newUser.Email || user.Phone == newUser.Phone)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
