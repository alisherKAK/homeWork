using HomeWork29_04_19.AbstractModels;

namespace HomeWork29_04_19.Models
{
    public class PurchasedTickets : Entity
    {
        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
