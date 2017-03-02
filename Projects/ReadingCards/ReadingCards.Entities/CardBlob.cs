using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.Entities
{
    public class CardBlob
    {
        public CardPoint LeftTopCorner { get; private set; }
        public CardPoint LeftBottomCorner { get; private set; }
        public CardPoint RightTopCorner { get; private set; }
        public CardPoint RightBottomCorner { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public CardBlob(CardPoint initialCorner,int width,int height)
        {
            if(initialCorner!=null)
            {
                this.LeftTopCorner = initialCorner;
                this.LeftBottomCorner = new CardPoint(this.LeftTopCorner.X, this.LeftTopCorner.Y + height);
                this.RightTopCorner = new CardPoint(this.LeftTopCorner.X + width, this.LeftTopCorner.Y);
                this.RightBottomCorner = new CardPoint(this.LeftTopCorner.X + width, this.LeftTopCorner.Y + height);
            }
            else
            {
                throw new NullReferenceException("Initial Corner cannot be null");
            }
        }

        public CardBlob(CardPoint leftTopCorner, CardPoint leftBottomCorner, CardPoint rightTopCorner, CardPoint rightBottomCorner)
        {
            if (leftTopCorner == null || leftBottomCorner == null || rightTopCorner == null || rightBottomCorner == null)
            {
                throw new NullReferenceException("Corner values cannot be null");
            }

            this.LeftTopCorner = leftTopCorner;
            this.LeftBottomCorner = leftBottomCorner;
            this.RightTopCorner = rightTopCorner;
            this.RightBottomCorner = rightBottomCorner;
        }
    }
}
