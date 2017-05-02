using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.IImageProcessing
{
    public abstract class ImageProcessingOps
    {
        public virtual string DrawRectangle(List<CardBlob> rectangles, string imagePath)
        {
            return "";
        }

        public virtual List<Bitmap> ExtractRectangle(List<CardBlob> rectangles, Bitmap bitmapImage)
        {
            return null;
        }

        public virtual Bitmap ConvertImage(Bitmap source)
        {
            return null;
        }

        public virtual Bitmap DrawRectangle(Bitmap source, ImageSource imgSource)
        {
            Bitmap withMaps = source.Clone() as Bitmap;

            List<Rectangle> rectangles = new List<Rectangle>();
            foreach(var cardItem in imgSource.cardItems)
            {
                if(cardItem.rank != Rank.NOT_RECOGNIZED)
                {
                    rectangles.Add(new Rectangle(cardItem.CardBlob.LeftBottomCorner.X, cardItem.CardBlob.LeftBottomCorner.Y, cardItem.CardBlob.Width, cardItem.CardBlob.Height));
                }
            }

            using (Graphics g = Graphics.FromImage(withMaps))
            {
                Color customColor = Color.FromArgb(50, Color.Yellow);
                SolidBrush shadowBrush = new SolidBrush(customColor);
                g.FillRectangles(shadowBrush, rectangles.ToArray());
            }

            return withMaps;
        }
    }
}
