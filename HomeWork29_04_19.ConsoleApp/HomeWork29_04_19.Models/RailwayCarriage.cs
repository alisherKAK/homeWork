using HomeWork29_04_19.AbstractModels;
using System.Collections.Generic;

namespace HomeWork29_04_19.Models
{
    public class RailwayCarriage : Entity
    {
        public int Number { get; set; }
        public virtual Train Train { get; set; }
        public virtual ICollection<Stateroom> Staterooms { get; set; }
    }
}
