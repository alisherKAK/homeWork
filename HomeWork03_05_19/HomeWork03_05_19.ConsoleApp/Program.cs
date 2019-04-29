using HomeWork03_05_19.ConstantsAndEnums;
using HomeWork03_05_19.DataAccess;
using HomeWork03_05_19.Models;
using HomeWork03_05_19.Services;
using System;
using System.Linq;

namespace HomeWork03_05_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFinished = false;
            bool isLogOuted = false;
            User currectUser = new User();

            do
            {
                switch (Menu.ChoseMenuActionsMenu())
                {
                    case MenuActions.Entry:
                        currectUser = Menu.Entry();
                        if (currectUser != null)
                        {
                            do
                            {
                                switch (Menu.ChoseUserActionsMenu())
                                {
                                    case UserActions.PutProduct:
                                        var product = Menu.ChoseProductMenu();
                                        using (var context = new CartContext())
                                        {
                                            CartProduct newCartProduct = new CartProduct()
                                            {
                                                Cart = context.Carts.Where(usersCart => usersCart.User.Id == currectUser.Id).SingleOrDefault(),
                                                Product = context.Products.Where(userProduct => userProduct.Id == product.Id).SingleOrDefault()
                                            };
                                            context.CartProducts.Add(newCartProduct);
                                            context.SaveChanges();
                                        }
                                        break;
                                    case UserActions.PullProduct:
                                        var cartProduct = Menu.ChoseUsersProductMenu(currectUser);
                                        using (var context = new CartContext())
                                        {
                                            context.CartProducts.Remove(context.CartProducts.Find(cartProduct.Id));
                                            context.SaveChanges();
                                        }
                                        break;
                                    case UserActions.ShowAllProduct:
                                        Menu.ShowAllUsersProducts(currectUser);
                                        break;
                                    case UserActions.Exit:
                                        isLogOuted = true;
                                        break;
                                    default:
                                        Console.WriteLine("Нет такого действие");
                                        break;
                                }
                            } while (!isLogOuted);
                        }
                        else
                        {
                            Console.WriteLine("Нет такого пользователя");
                        }
                        break;
                    case MenuActions.Registration:
                        Menu.Registration();
                        break;
                    case MenuActions.Exit:
                        isFinished = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого действие");
                        break;
                }
            } while (!isFinished);
        }
    }
}
