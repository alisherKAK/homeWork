using HomeWork29_04_19.AbstractModels;
using System;
using System.Collections.Generic;

namespace HomeWork29_04_19.Models
{
    public class RailwayCarriage : Entity
    {
        public int Number { get; set; }
        public Guid TrainId { get; set; }
        public Train Train { get; set; }
        public ICollection<Stateroom> Staterooms { get; set; }
    }
}
