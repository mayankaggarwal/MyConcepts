using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.ImageProcessing
{
    public static class ImageBlobExtractor
    {
        public static void ExtractBlobs(Bitmap image)
        {
//            BlobCounter extractor = new BlobCounter();
//            extractor.FilterBlobs = true;
//            extractor.MinWidth = extractor.MinHeight = 100;
//            extractor.MaxWidth = extractor.MaxHeight = 150;
//            extractor.ProcessImage(image);
//           QuadrilateralTransformation quadTransformer = new QuadrilateralTransformation();
////Will be used resize(scaling) cards
//ResizeBilinear resizer = new ResizeBilinear(CardWidth, CardHeight);

//foreach (Blob blob in extractor.GetObjectsInformation())
//{
//     //Get Edge points of card
//     List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
//     //Find corners of card on source image from edge points
//     List<IntPoint> corners =  PointsCloud.FindQuadrilateralCorners(edgePoints);
//     Bitmap cardImg = quadTransformer.Apply(source); //Extract(transform) card image

//     if (cardImg.Width > cardImg.Height) //If card is positioned horizontally
//          cardImg.RotateFlip(RotateFlipType.Rotate90FlipNone); //Rotate
//     cardImg =  resizer.Apply(cardImg);
//}
            //return image;
        }
    }
}
