using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.AForgeImplementation
{

    public class CardDetector
    {
        public int MinWidth { get; private set; }
        public int MaxWidth { get; private set; }
        public int MinHeight { get; private set; }
        public int MaxHeight { get; private set; }
        private BlobCounterBase extractor;

        public CardDetector(
            BlobDetectionAlgorithmType algo,
            int minWidth,
            int maxWidth,
            int minHeight,
            int maxHeight)
        {
            this.MinWidth = minWidth;
            this.MaxWidth = maxWidth;
            this.MinHeight = minHeight;
            this.MaxHeight = maxHeight;

            extractor = BlobDetectionAlgorithm(algo);
        }

        private BlobCounterBase BlobDetectionAlgorithm(BlobDetectionAlgorithmType algo)
        {
            switch (algo)
            {
                case BlobDetectionAlgorithmType.CCL:
                    return new BlobCounter();
                case BlobDetectionAlgorithmType.RCCL:
                    return new RecursiveBlobCounter();
                default:
                    return new BlobCounter();
            }
        }

        public List<CardBlob> GetBlobs(System.Drawing.Bitmap image)
        {
            List<CardBlob> lstCardBlob = new List<CardBlob>();
            using (Bitmap temp = image as Bitmap)
            {
                extractor.FilterBlobs = true;
                extractor.MinWidth = this.MinWidth;
                extractor.MaxWidth = this.MaxWidth;
                extractor.MinHeight = this.MinHeight;
                extractor.MaxHeight = this.MaxHeight;
                extractor.ProcessImage(temp);

                foreach(Blob blob in extractor.GetObjectsInformation())
                {
                    List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                    List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);
                    //IntPoint leftTop = corners.Where(x => x.X == corners.Min(y => y.X) && x.Y == corners.Min(y=>y.Y)).FirstOrDefault();
                    //IntPoint rightBottom = corners.Where(x => x.X == corners.Max(y => y.X) && x.Y == corners.Max(y => y.Y)).FirstOrDefault();
                    if(corners.Count==4)
                    {
                        lstCardBlob.Add(new CardBlob(
                            new CardPoint(corners[0].X, corners[0].Y),
                            new CardPoint(corners[1].X, corners[1].Y),
                            new CardPoint(corners[2].X, corners[2].Y),
                            new CardPoint(corners[3].X, corners[3].Y)
                            ));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            return lstCardBlob;
        }
    }
}
