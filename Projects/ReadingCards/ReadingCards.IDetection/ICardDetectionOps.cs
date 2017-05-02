using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.IDetection
{
    public abstract class ICardDetectionOps
    {
        public abstract List<CardBlob> GetBlobs(Bitmap image);
    }
}
