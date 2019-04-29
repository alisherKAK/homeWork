using HomeWork03_05_19.AbstractModels;
using System.Collections.Generic;

namespace HomeWork03_05_19.Models
{
    public class Cart : Entity
    {
        public virtual User User { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
