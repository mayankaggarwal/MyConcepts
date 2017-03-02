using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.Entities
{
    public class CardPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public CardPoint(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
