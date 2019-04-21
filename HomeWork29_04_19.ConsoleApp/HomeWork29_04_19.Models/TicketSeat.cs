using HomeWork29_04_19.AbstractModels;
using System;

namespace HomeWork29_04_19.Models
{
    public class TicketSeat : Entity
    {
        public Guid TrainId { get; set; }
        public Train Train { get; set; }
        public Guid RailwayCarriageId { get; set; }
        public RailwayCarriage RailwayCarriage { get; set; }
        public Guid StateroomId { get; set; }
        public Stateroom Stateroom { get; set; }
        public Guid SpotId { get; set; }
        public Spot Spot { get; set; }
    }
}
