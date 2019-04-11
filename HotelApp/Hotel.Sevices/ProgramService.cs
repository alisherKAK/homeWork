using System;
using Hotel.DataAccess;
using Hotel.Models;
using Hotel.Services.Abstract;

namespace Hotel.Sevices
{
    public static class ProgramService
    {
        public static User Registration()
        {
            TableDataService<User> dataService = new TableDataService<User>();
            var users = dataService.GetAll();

            User newUser = new User()
            {
                Login = SetInformation.SetLogin(),
                Password = SetInformation.SetPassword(),
                Email = SetInformation.SetEmail(),
                Phone = SetInformation.SetPhoneNumber()
            };


            foreach(User user in users)
            {
                if(user.Login == newUser.Login || user.Phone == newUser.Phone)
                {
                    throw new ArgumentException("Уже есть user с таким логином или телефоном");
                }
            }

            ISender sender = GetSeneder.GetSender(Senders.TelegramSender);

            sender.Open();
            sender.Send("Чтобы получить код нужно написать боту 'Get code', затем введите его,\n" +
                        "если пропала ссылка перейдите по такому адресу: https://web.telegram.org/#/im?p=@StepCodeSendMessageBot");
            CheckCode();
            sender.Close();

            return newUser;
        }

        public static void CheckCode()
        {
            try
            {
                Console.WriteLine("Введите полученный код:");

                string code = Console.ReadLine().Trim();

                if(code == CodeGenerator.Code)
                {
                    return;
                }

                throw new ArgumentException("Неверный код");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                CheckCode();
            }
        }

        public static bool Enter(User currentUser)
        {
            TableDataService<User> dataService = new TableDataService<User>();
            
            var users = dataService.GetAll();
            
            string login = SetInformation.SetLogin();
            string password = SetInformation.SetPassword();
            
            foreach(User user in users)
            {
                if(user.Login == login && user.Password == password)
                {
                    currentUser.Id = user.Id;
                    currentUser.Login = user.Login;
                    currentUser.Password = user.Password;
                    currentUser.Phone = user.Phone;
                    currentUser.Email = user.Email;
                    return true;
                }
            }
            
            return false;
        }

        public static int ChoseEnter()
        {
            try
            {
                Console.WriteLine("1) Registration\n" +
                                  "2) Enter\n" +
                                  "3) Exit");

                int chose;

                if(int.TryParse(Console.ReadLine().Trim(), out chose))
                {
                    return chose;
                }

                throw new ArgumentException("Ввели неправильно число");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return ChoseEnter();
            }
        }

        public static Hotel.Models.Hotel ChoseHotel()
        {
            try
            {
                TableDataService<Hotel.Models.Hotel> dataService = new TableDataService<Hotel.Models.Hotel>();
                var hotels = dataService.GetAll();

                Console.WriteLine("Выберите отель\n" +
                                  "=========================================\n");


                for (int i = 0; i < hotels.Count; i++)
                {
                    Console.WriteLine($"{hotels[i].Id}) {hotels[i].Name}");
                }

                int hotelId;

                if(int.TryParse(Console.ReadLine().Trim(), out hotelId) && hotelId <= hotels.Count && hotelId >= 1)
                {
                    for (int i = 0; i < hotels.Count; i++)
                    {
                        if(hotels[i].Id == hotelId)
                        {
                            return hotels[i];
                        }
                    }
                }

                throw new ArgumentException("Такого отеля нет");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return ChoseHotel();
            }
        }

        public static Room ChoseRoom(int hotelId)
        {
            try
            {
                TableDataService<Room> dataService = new TableDataService<Room>();

                var rooms = dataService.GetAll();

                Console.WriteLine("Выберите комнату, если ее нет нажмите ESC\n" +
                                  "=========================================\n");

                for(int i = 0; i < rooms.Count; i++)
                {
                    if(rooms[i].HotelId == hotelId)
                    {
                        Console.WriteLine($"{rooms[i].Id}) {rooms[i].Number} : {rooms[i].PricePerDay} to day");
                    }
                }

                int roomId;

                if(int.TryParse(Console.ReadLine().Trim(), out roomId))
                {
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (rooms[i].HotelId == hotelId && rooms[i].Id == roomId)
                        {
                            return rooms[i];
                        }
                    }
                }

                throw new ArgumentException("Такой комнаты нет");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return ChoseRoom(hotelId);
            }
        }
    }
}
