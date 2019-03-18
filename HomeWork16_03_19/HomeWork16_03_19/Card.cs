using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_03_19
{
    public class Card
    {
        public CardTypes Type { get; set; }
        public Lears Lear { get; set; }

        public Card(){}
        public Card(CardTypes type, Lears lear)
        {
            Type = type;
            Lear = lear;
        }
        public Card(Lears lear, CardTypes type)
        {
            Type = type;
            Lear = lear;
        }

        public static bool operator==(Card card1, Card card2)
        {
            if(card1.Lear == card2.Lear && card1.Type == card2.Type)
            {
                return true;
            }

            return false;
        }
        public static bool operator!=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
        public static bool operator>(Card card1, Card card2)
        {
            if (card1.Type > card2.Type)
            {
                return true;
            }
            
            return false;
        }
        public static bool operator<(Card card1, Card card2)
        {
            return !(card1 > card2);

        }
    }
}
