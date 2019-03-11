using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14_03_19
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IdAttribute : Attribute
    {
        public Guid Id { get; set; }

        public IdAttribute()
        {
            Id = Guid.NewGuid();
        }
    }
}
