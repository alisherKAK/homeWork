using HomeWork03_05_19.AbstractModels;
using System;

namespace HomeWork03_05_19.Models
{
    public class Product : Entity
    {
        public virtual ProductType ProductType { get; set; }
        public double Price { get; set; }
        public DateTime ProducedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
