using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.Entities
{
    public class ImageSource:IDisposable
    {
        public Dictionary<ImageType, Bitmap> imageSources { get; private set; }
        public List<CardItem> cardItems;
        public ImageSource()
        {
            imageSources = new Dictionary<ImageType, Bitmap>();
            cardItems = new List<CardItem>();
        }

        public bool AddImage(ImageType imageType, Bitmap image, bool overwriteExisting = false)
        {
            if(imageSources.ContainsKey(imageType))
            {
                if (overwriteExisting)
                {
                    imageSources.Remove(imageType);
                    imageSources.Add(imageType, image);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                imageSources.Add(imageType, image);
                return true;
            }
        }

        public bool AddCardItem(List<CardItem> cardItems)
        {
            foreach (CardItem cardItem in cardItems)
                AddCardItem(cardItem);

            return true;
        }

        public bool AddCardItem(CardItem cardItem)
        {
            this.cardItems.Add(cardItem);

            return true;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(!disposed)
                {
                    imageSources = null;
                    disposed = true;
                }
            }
        }
    }
}
