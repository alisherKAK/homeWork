using HomeWork03_05_19.AbstractModels;

namespace HomeWork03_05_19.Models
{
    public class CartProduct : Entity
    {
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
