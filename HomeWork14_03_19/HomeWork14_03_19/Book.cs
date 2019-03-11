using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14_03_19
{
    [Serializable]
    [Id]
    public class Book
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public int PressYear { get; set; }
    }
}
