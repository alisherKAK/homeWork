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

            while(true)
            {
                switch (ProgramService.ChoseEnter())
                {
                    case Constants.REGISTRATION_CHOSE:
                        ProgramService.Registration();
                        break;
                    case Constants.ENTRY_CHOSE:
                        if(ProgramService.Enter())
                        {
                            isEnter = true;
                        }
                        break;
                    case Constants.EXIT_CHOSE:
                        isFinish = true;
                        break;
                }
                if(isFinish == true || isEnter == true)
                {
                    break;
                }
            }


        }
    }
}
