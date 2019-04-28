using HomeWork29_04_19.ConstantsAndEnums;
using HomeWork29_04_19.DataAccess;
using HomeWork29_04_19.Models;
using System;
using System.Linq;

namespace HomeWork29_04_19.Services
{
    public static class Menu
    {
        public static UserMenuActions UserMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Entr\n" +
                                      "2) Registration\n" +
                                      "3) Exit");

                    int userMenuAction;

                    if(int.TryParse(Console.ReadLine().Trim(), out userMenuAction))
                    {
                        return (UserMenuActions)userMenuAction;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static UserActions UserActionsMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Buy ticket");

                    int userAction;

                    if(int.TryParse(Console.ReadLine().Trim(), out userAction))
                    {
                        return (UserActions)userAction;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message
);
                }
            } while (true);
        }

        public static City LocatedCityChoseMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите город отбытия:");

                    string locatedCity = Console.ReadLine().Trim();

                    if(locatedCity.Where(letter => (letter >= 'a' && letter <= 'z') ||
                                                   (letter >= 'A' && letter <= 'Z')).ToList().Count == locatedCity.Length)
                    {
                        using(var context = new TicketContext())
                        {
                            return context.Cities.Where(city => city.Name.ToLower() == locatedCity.ToLower()).SingleOrDefault();
                        }
                    }

                    throw new ArgumentException("Название города было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static City DepartureCityChoseMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите город прибытия:");

                    string departureCity = Console.ReadLine().Trim();

                    if (departureCity.Where(letter => (letter >= 'a' && letter <= 'z') ||
                                                    (letter >= 'A' && letter <= 'Z')).ToList().Count == departureCity.Length)
                    {
                        using (var context = new TicketContext())
                        {
                            return context.Cities.Where(city => city.Name.ToLower() == departureCity.ToLower()).SingleOrDefault();
                        }
                    }

                    throw new ArgumentException("Название города было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static void BuyTicket(City locatedCity, City departureCity, User user)
        {
            do
            {
                try
                {
                    using(var context = new TicketContext())
                    {
                        var tickets = context.Tickets.Where(ticket => ticket.LocatedCity.Id == locatedCity.Id && ticket.DepartureCity.Id == departureCity.Id && ticket.IsBuyed == false).ToList();
                        for(int i = 0; i < tickets.Count; i++)
                        {
                            Console.WriteLine("=========================================================");
                            Console.WriteLine($"{i+1}) {tickets[i].LocatedCity}-{tickets[i].DepartureCity} Поезд:{tickets[i].TicketSeat.Train.Model} Вагон: {tickets[i].TicketSeat.RailwayCarriage.Number}; Купе: {tickets[i].TicketSeat.Stateroom.Number}; Место: {tickets[i].TicketSeat.Spot.Number}; Цена: {tickets[i].Price}; Время отбытия: {tickets[i].DispatchTime}; Время прибытия: {tickets[i].ArrivalTime};");
                            Console.WriteLine("=========================================================");
                        }
                    }

                    int ticketIndex;

                    if(int.TryParse(Console.ReadLine().Trim(), out ticketIndex))
                    {
                        using(var context = new TicketContext())
                        {
                            var ticket = context.Tickets.ToList()[ticketIndex - 1];
                            ticket.IsBuyed = true;
                            context.SaveChanges();

                            context.PurchasedTickets.Add(new PurchasedTickets()
                            {
                                Ticket = context.Tickets.Find(ticket.Id),
                                User = context.Users.Find(user.Id)
                            });
                            context.SaveChanges();
                        }

                        return;
                    }

                    throw new ArgumentException("Число было неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static User Entry()
        {
            string login = SetInformation.SetLogin();
            string password = SetInformation.SetPassword();

            using(var context = new TicketContext())
            {
                return context.Users.Where(user => user.Login == login && user.Password == password).SingleOrDefault();
            }
        }

        public static void Registration()
        {
            Person newPerson = new Person()
            {
                Name = SetInformation.SetName(),
                Surname = SetInformation.SetSurname(),
                Email = SetInformation.SetEmail()
            };
            string login = SetInformation.SetLogin();

            using(var context = new TicketContext())
            {
                if(!(context.Users.Where(user => user.Login == login).ToList().Count == Constants.NULL))
                {
                    return;
                }
            }

            User newUser = new User()
            {
                Login = login,
                Password = SetInformation.SetPassword(),
                Person = newPerson
            };

            using(var context = new TicketContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }
    }
}
