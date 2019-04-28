using HomeWork29_04_19.AbstractModels;
using System;

namespace HomeWork29_04_19.Models
{
    public class Ticket : Entity
    {
        public virtual TicketSeat TicketSeat { get; set; }
        public double Price { get; set; }
        public virtual City LocatedCity { get; set; }
        public virtual City DepartureCity { get; set; }
        public DateTime DispatchTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool IsBuyed { get; set; }
    }
}
