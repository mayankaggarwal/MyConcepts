using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.Detection.OpenCVImplementation
{
    public class CardDetector:IDetection.ICardDetectionOps
    {
        public CardDetector()
        {
               
        }
        public override List<CardBlob> GetBlobs(Bitmap image)
        {

            return null;
        }
    }
}
