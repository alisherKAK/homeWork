using HomeWork26_04_19.DataAccess;
using HomeWork26_04_19.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork26_04_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinish = false;

            do
            {
                switch (ChoicesMenu.ChoseOperation())
                {
                    case (int)Operations.Add:
                        switch (ChoicesMenu.ChoseModel())
                        {
                            case (int)TableModels.Producer:
                                OperationsWithObject.AddProducer();
                                break;
                            case (int)TableModels.Product:
                                try
                                {
                                    OperationsWithObject.AddProduct();
                                }
                                catch(ArgumentNullException exception)
                                {
                                    Console.WriteLine(exception.ParamName);
                                }
                                break;
                            default:
                                Console.WriteLine("Нет такого объекта");
                                break;
                        }
                        break;
                    case (int)Operations.Delete:
                        try
                        {
                            OperationsWithObject.DeleteProductById(ChoicesMenu.ChoseProduct().Id);
                        }
                        catch(ArgumentNullException exception)
                        {
                            Console.WriteLine(exception.ParamName);
                        }
                        break;
                    case (int)Operations.Edit:
                        try
                        {
                            OperationsWithObject.EditProduct(ChoicesMenu.ChoseProduct());
                        }
                        catch (ArgumentNullException exception)
                        {
                            Console.WriteLine(exception.ParamName);
                        }
                        break;
                    case Constants.EXIT_CHOSE:
                        isFinish = true;
                        break;
                    default:
                        Console.WriteLine("Нет такой операций");
                        break;
                }

                Console.WriteLine("============================");
            } while (!isFinish);
        }
    }
}
