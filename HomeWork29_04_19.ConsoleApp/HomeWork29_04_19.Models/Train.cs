using HomeWork29_04_19.AbstractModels;
using System.Collections.Generic;

namespace HomeWork29_04_19.Models
{
    public class Train : Entity
    {
        public string Model { get; set; }
        public virtual ICollection<RailwayCarriage> RailwayCarriages { get; set; }
    }
}
