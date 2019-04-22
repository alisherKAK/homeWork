using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02_05_19.Services
{
    public static class Menu
    {
        public static Actions ActionMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите действие:\n" +
                                      "1) Добавить\n" +
                                      "2) Пойск\n" +
                                      "3) Выход");

                    int action;

                    if(int.TryParse(Console.ReadLine().Trim(), out action))
                    {
                        return (Actions)action;
                    }

                    throw new ArgumentException("Число было введено некоректно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Models AddMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Что вы хотите добавить:\n" +
                                      "1) Группу\n" +
                                      "2) Музыку");

                    int addModel;

                    if(int.TryParse(Console.ReadLine().Trim(), out addModel))
                    {
                        return (Models)addModel;
                    }

                    throw new ArgumentException("Число было некоректно введено");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static int BandSelectMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите группу, если ее нет тогда нажмите на '0'");

                    var bands = SelectInformation.SelectAllBand();

                    for (int i = 0; i < bands.Count; i++)
                    {
                        Console.WriteLine($"{i+Constants.LENGTH_TO_INDEX} {bands[i].Name}");
                    }

                    int bandIndex;

                    if(int.TryParse(Console.ReadLine().Trim(), out bandIndex)) 
                    {
                        if(bandIndex > Constants.FIRST_ELEMENT_INDEX && bandIndex <= bands.Count)
                        {
                            return bandIndex;
                        }

                        throw new ArgumentException("Нет группы с таким номером");
                    }

                    throw new ArgumentException("Число было введено некоректно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
