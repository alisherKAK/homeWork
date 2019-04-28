using HomeWork29_04_19.AbstractModels;

namespace HomeWork29_04_19.Models
{
    public class TicketSeat : Entity
    {
        public virtual Train Train { get; set; }
        public virtual RailwayCarriage RailwayCarriage { get; set; }
        public virtual Stateroom Stateroom { get; set; }
        public virtual Spot Spot { get; set; }
    }
}
