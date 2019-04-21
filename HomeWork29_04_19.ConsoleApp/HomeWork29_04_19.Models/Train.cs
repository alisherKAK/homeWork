using HomeWork29_04_19.AbstractModels;
using System;
using System.Collections.Generic;

namespace HomeWork29_04_19.Models
{
    public class Train : Entity
    {
        public string Model { get; set; }
        public Guid LocatedCityId { get; set; }
        public City LocatedCity { get; set; }
        public ICollection<RailwayCarriage> RailwayCarriages { get; set; }
    }
}
