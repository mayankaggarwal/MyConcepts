using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.Entities
{
    public class CardItem
    {
        public Bitmap CardImage { get; private set; }
        public CardBlob CardBlob { get; private set; }
        public Rank rank { get; set; }
        public Suit suit { get; set; }
        public short confidence { get; set; }

        public CardItem(CardBlob cardBlob)
        {

        }

        public CardItem(Bitmap cardImage)
        {
            this.CardImage = cardImage.Clone() as Bitmap;
        }

        public CardItem(CardBlob cardBlob, Bitmap cardImage)
        {
            this.CardImage = cardImage.Clone() as Bitmap;
            this.CardBlob = cardBlob;
        }
    }
}
