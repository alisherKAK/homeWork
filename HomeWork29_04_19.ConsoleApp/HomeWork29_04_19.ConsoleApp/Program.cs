using HomeWork29_04_19.ConstantsAndEnums;
using HomeWork29_04_19.Models;
using HomeWork29_04_19.Services;
using System;

namespace HomeWork29_04_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinish = false;
            User currentUser = new User();

            do
            {
                switch (Menu.UserMenu())
                {
                    case UserMenuActions.Entry:
                        currentUser = Menu.Entry();
                        switch(Menu.UserActionsMenu())
                        {
                            case UserActions.BuyTicket:
                                var locatedCity = Menu.LocatedCityChoseMenu();
                                var departureCity = Menu.DepartureCityChoseMenu();
                                Menu.BuyTicket(locatedCity, departureCity, currentUser);
                                break;
                            default:
                                Console.WriteLine("Нет такого дествия");
                                break;
                        }
                        break;
                    case UserMenuActions.Registration:
                        Menu.Registration();
                        break;
                    case UserMenuActions.Exit:
                        isFinish = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого дествия");
                        break;
                }
            } while (!isFinish);
        }
    }
}
