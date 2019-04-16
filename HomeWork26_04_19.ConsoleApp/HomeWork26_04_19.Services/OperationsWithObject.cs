﻿using HomeWork26_04_19.DataAccess;
using HomeWork26_04_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork26_04_19.Services
{
    public static class OperationsWithObject
    {
        public static void AddProducer()
        {
            Producer newProducer = new Producer()
            {
                Name = SetInformation.SetName()
            };

            using(var context = new StockContext())
            {
                context.Producers.Add(newProducer);
                context.SaveChanges();
            }
        }

        public static void AddProduct()
        {
            try
            {
                string name = SetInformation.SetName();
                DateTime productionDate = SetInformation.SetProductionDate();
                DateTime expirationDate = SetInformation.SetExpirationDate(productionDate);
                double price = SetInformation.SetPrice();
                int amount = SetInformation.SetAmount();
                Guid producerId = SetInformation.SetProducerId();

                Product newProduct = new Product()
                {
                    Name = name,
                    ProductionDate = productionDate,
                    ExpirationDate = expirationDate,
                    Price = price,
                    Amount = amount,
                    ProducerId = producerId
                };

                using (var context = new StockContext())
                {
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }
            }
            catch(ArgumentNullException)
            {
                throw;
            }
        }

        public static void DeleteProductById(Guid id)
        {
            using(var context = new StockContext())
            {
                var findedProduct = context.Products.Find(id);
                context.Products.Remove(findedProduct);
            }
        }

        public static void EditProduct(Product product)
        {
            switch (ChoicesMenu.ChoseColumn())
            {
                case (int)Columns.Name:
                    product.Name = SetInformation.SetName();
                    break;
                case (int)Columns.Price:
                    product.Price = SetInformation.SetPrice();
                    break;
                case (int)Columns.Amount:
                    product.Amount = SetInformation.SetAmount();
                    break;
                case (int)Columns.ProductionDate:
                    product.ProductionDate = SetInformation.SetProductionDate();
                    break;
                case (int)Columns.ExpirationDate:
                    product.ExpirationDate = SetInformation.SetExpirationDate(product.ProductionDate);
                    break;
                case (int)Columns.ProducerId:
                    product.ProducerId = SetInformation.SetProducerId();
                    break;
                default:
                    Console.WriteLine("Нет такого поля");
                    break;
            }

            using(var context = new StockContext())
            {
                var changeProduct = context.Products.Find(product.Id);
                context.Products.Remove(changeProduct);
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }
}
