using Hotel.DataAccess;
using Hotel.Models;
using Hotel.Services.Abstract;
using Hotel.Sevices;
using HotelConstants;
using System;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinish = false;
            bool isEnter = false;
            User currentUser = new User();

            while(true)
            {
                switch (ProgramService.ChoseEnter())
                {
                    case Constants.REGISTRATION_CHOSE:
                        try
                        {
                            TableDataService<User> dataService = new TableDataService<User>();
                            User newUser = ProgramService.Registration();
                            dataService.Add(newUser);
                        }
                        catch(ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case Constants.ENTRY_CHOSE:
                        if(ProgramService.Enter(currentUser))
                        {
                            isEnter = true;
                        }
                        else
                        {
                            Console.WriteLine("Нету такого user");
                        }
                        break;
                    case Constants.EXIT_CHOSE:
                        isFinish = true;
                        break;
                }
                if(isEnter == true)
                {
                    TableDataService<BookingBook> dataService = new TableDataService<BookingBook>();

                    Hotel.Models.Hotel chosenHotel = ProgramService.ChoseHotel();
                    Room chosenRoom = ProgramService.ChoseRoom(chosenHotel.Id);
                    DateTime beginDate = SetInformation.SetBeginDateAndTime();
                    DateTime endDate = SetInformation.SetEndDateAndTime(beginDate);

                    BookingBook bookingBook = new BookingBook()
                    {
                        UserId = currentUser.Id,
                        RoomId = chosenRoom.Id,
                        BeginDate = beginDate,
                        EndDate = endDate
                    };
                    dataService.Add(bookingBook);

                    IPayer payer = GetPayers.GetPayer(Payers.PayPal);
                    payer.Pay($"{chosenRoom.Number} room", 
                        ((endDate - beginDate).Days * chosenRoom.PricePerDay).ToString());


                    isEnter = false;
                }
                else if(isFinish == true)
                {
                    break;
                }
            }
        }
    }
}
