using HomeWork29_04_19.AbstractModels;
using System;

namespace HomeWork29_04_19.Models
{
    public class Spot : Entity
    {
        public int Number { get; set; }
        public Guid StateroomId { get; set; }
        public Stateroom Stateroom { get; set; }
    }
}
