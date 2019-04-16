using HomeWork26_04_19.DataAccess;
using HomeWork26_04_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork26_04_19.Services
{
    public static class ChoicesMenu
    {
        public static int ChoseColumn()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите поле которое хотите изменить:\n" +
                                      "1) Name\n" +
                                      "2) Price\n" +
                                      "3) Amount\n" +
                                      "4) Production Date\n" +
                                      "5) Expiration Date\n" +
                                      "6) ProducerId");

                    int column;

                    if(int.TryParse(Console.ReadLine().Trim(), out column))
                    {
                        return column;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
        public static int ChoseOperation()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите операцию которую хотите совершить с данными:\n" +
                                      "1) Add\n" +
                                      "2) Remove\n" +
                                      "3) Edit\n" +
                                      "4) Exit");

                    int operation;

                    if(int.TryParse(Console.ReadLine().Trim(), out operation))
                    {
                        return operation;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
        public static Product ChoseProduct()
        {
            do
            {
                try
                {
                    using(var context = new StockContext())
                    {
                        var products = context.Products.ToList();

                        if (products.Count > Constants.NULL)
                        {
                            Console.WriteLine("Выберите продкут:");
                            for (int i = 0; i < products.Count; i++)
                            {
                                Console.WriteLine($"{i + Constants.INDEX_TO_LENGTH}) {products[i].Name}");
                            }

                            int productIndex;

                            if (int.TryParse(Console.ReadLine().Trim(), out productIndex))
                            {
                                return products[productIndex];
                            }

                            throw new ArgumentException("Неверно ввели число");
                        }

                        throw new ArgumentNullException("Нет ни одного продукта, добавьте хоть одного");
                    }
                }
                catch(ArgumentNullException)
                {
                    throw;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(IndexOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
        public static int ChoseModel()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберте что хотите добваить:\n" +
                                      "1) Producer\n" +
                                      "2) Product");

                    int chosenModel;

                    if(int.TryParse(Console.ReadLine().Trim(), out chosenModel))
                    {
                        return chosenModel;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }
    }
}
