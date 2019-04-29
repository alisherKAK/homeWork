using HomeWork03_05_19.ConstantsAndEnums;
using HomeWork03_05_19.DataAccess;
using HomeWork03_05_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork03_05_19.Services
{
    public static class Menu
    {
        public static MenuActions ChoseMenuActionsMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Войти\n" +
                                      "2) Регистрация\n" +
                                      "3) Выход");

                    int menuAction;

                    if(int.TryParse(Console.ReadLine().Trim(), out menuAction))
                    {
                        return (MenuActions)menuAction;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static UserActions ChoseUserActionsMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("1) Положить товар в корзину\n" +
                                      "2) Вытащить товар с корзины\n" +
                                      "3) Вывести все товары в крозине\n" +
                                      "4) Выход");

                    int userAction;

                    if(int.TryParse(Console.ReadLine().Trim(), out userAction))
                    {
                        return (UserActions)userAction;
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static Product ChoseProductMenu()
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите товар:");
                    using(var context = new CartContext())
                    {
                        var products = context.Products.ToList();
                        for(int i = 0; i < products.Count; ++i)
                        {
                            Console.WriteLine($"{i+1}) {products[i].ProductType.Name}:{products[i].Price}\n" +
                           $"Дата производства: {products[i].ProducedDate} Срок годности: {products[i].ExpirationDate}");
                        }
                    }

                    int productIndex;

                    if(int.TryParse(Console.ReadLine().Trim(), out productIndex))
                    {
                        using(var context = new CartContext())
                        {
                            return context.Products.ToList()[productIndex - 1];

                        }
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static CartProduct ChoseUsersProductMenu(User user)
        {
            do
            {
                try
                {
                    Console.WriteLine("Выберите товар:");
                    List<Product> products = new List<Product>();

                    using (var context = new CartContext())
                    {
                        var cartProducts = context.Carts.Where(cart => cart.User.Id == user.Id).SingleOrDefault().CartProducts.ToList();

                        foreach(CartProduct cartProduct in cartProducts)
                        {
                            products.AddRange(context.Products.Where(product => product.Id == cartProduct.Product.Id).ToList());
                        }

                        for(int i = 0; i < products.Count; ++i)
                        {
                            Console.WriteLine($"{i + 1}) {products[i].ProductType.Name}:{products[i].Price}\n" +
                           $"Дата производства: {products[i].ProducedDate} Срок годности: {products[i].ExpirationDate}");
                        }
                    }

                    int productIndex;

                    if(int.TryParse(Console.ReadLine().Trim(), out productIndex))
                    {
                        using(var context = new CartContext())
                        {
                            foreach(CartProduct cartProduct in context.CartProducts.ToList())
                            {
                                if(cartProduct.Product.Id == products[productIndex-1].Id)
                                {
                                    return cartProduct;
                                }
                            }
                        }
                    }

                    throw new ArgumentException("Число было введено неверно");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (true);
        }

        public static User Entry()
        {
            string login = SetInformations.SetLogin();
            string password = SetInformations.SetPassword();

            using(var context = new CartContext())
            {
                return context.Users.Where(user => user.Login == login && user.Password == password).SingleOrDefault();
            }
        }

        public static void Registration()
        {
            User newUser = new User()
            {
                Login = SetInformations.SetLogin(),
                Password = SetInformations.SetPassword()
            };
            Cart newCart = new Cart()
            {
                User = newUser
            };

            using(var context = new CartContext())
            {
                if(context.Users.All(user => user.Login != newUser.Login))
                {
                    context.Carts.Add(newCart);
                    context.SaveChanges();
                }
            }
        }

        public static void  ShowAllUsersProducts(User user)
        {
            using(var context = new CartContext())
            {
                var cartProducts = context.Carts.Where(cart => cart.User.Id == user.Id).SingleOrDefault().CartProducts.ToList();

                cartProducts.ForEach(cartProduct => Console.WriteLine($"{cartProduct.Product.ProductType.Name}:{cartProduct.Product.Price}\n" +
                           $"Дата производства: {cartProduct.Product.ProducedDate} Срок годности: {cartProduct.Product.ExpirationDate}"));
            }
        }
    }
}
