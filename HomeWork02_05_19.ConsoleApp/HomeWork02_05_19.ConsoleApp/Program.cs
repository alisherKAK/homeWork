using HomeWork02_05_19.Models;
using HomeWork02_05_19.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02_05_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinish = false;

            do
            {
                switch (Menu.ActionMenu())
                {
                    case Actions.Add:
                        switch (Menu.AddMenu())
                        {
                            case Services.Models.Band:
                                SaveModelsInDataBase.SaveBand(ModelCreator.CreateBand());
                                break;
                            case Services.Models.Music:
                                do
                                {
                                    try
                                    {
                                        SaveModelsInDataBase.SaveMusic(ModelCreator.CreateMusic(SelectInformation.SelectBandByIndex(Menu.BandSelectMenu())));

                                        break;
                                    }
                                    catch(IndexOutOfRangeException)
                                    {
                                        Console.WriteLine("Такая группа уже существует");
                                    }
                                } while (true);
                                break;
                            default:
                                Console.WriteLine("Нет такого объекта");
                                break;
                        }
                        break;
                    case Actions.View:
                        break;
                    case Actions.Exit:
                        isFinish = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого действия");
                        break;
                }
            } while (!isFinish);
        }
    }
}
