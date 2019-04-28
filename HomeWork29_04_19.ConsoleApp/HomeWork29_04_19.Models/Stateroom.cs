using HomeWork29_04_19.AbstractModels;
using System.Collections.Generic;

namespace HomeWork29_04_19.Models
{
    public class Stateroom : Entity
    {
        public int Number { get; set; }
        public virtual RailwayCarriage RailwayCarriage { get; set; }
        public virtual ICollection<Spot> Spots { get; set; }
    }
}
