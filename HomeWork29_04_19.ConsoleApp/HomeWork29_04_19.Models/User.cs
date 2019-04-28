using HomeWork29_04_19.AbstractModels;
using System.Collections.Generic;

namespace HomeWork29_04_19.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
