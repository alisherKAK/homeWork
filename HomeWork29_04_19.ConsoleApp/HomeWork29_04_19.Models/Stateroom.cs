using HomeWork29_04_19.AbstractModels;
using System;
using System.Collections.Generic;

namespace HomeWork29_04_19.Models
{
    public class Stateroom : Entity
    {
        public int Number { get; set; }
        public Guid RailwayCarriageId { get; set; }
        public RailwayCarriage RailwayCarriage { get; set; }
        public ICollection<Spot> Spots { get; set; }
    }
}
