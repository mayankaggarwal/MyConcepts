using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.ImageProcessing
{
    public static class ImageFormatter
    {
        public static Bitmap ConvertImage(Bitmap source)
        {
            Bitmap temp = source.Clone() as Bitmap; //Clone image to keep original image

            FiltersSequence seq = new FiltersSequence();
            seq.Add(Grayscale.CommonAlgorithms.BT709);  //First add  GrayScaling filter
            seq.Add(new OtsuThreshold()); //Then add binarization(thresholding) filter
            temp = seq.Apply(source); // Apply filters on source image
            BlobCounter extractor = new BlobCounter();
            extractor.FilterBlobs = true;
          
            extractor.MinWidth = extractor.MinHeight = 100;
            extractor.MaxWidth = extractor.MaxHeight = 200;
            extractor.ProcessImage(temp);
            QuadrilateralTransformation quadTransformer = new QuadrilateralTransformation();
            //Will be used resize(scaling) cards
            ResizeBilinear resizer = new ResizeBilinear(100, 150);
            int i = 0;
            foreach (Blob blob in extractor.GetObjectsInformation())
            {
                i++;
                //Get Edge points of card
                List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
                //Find corners of card on source image from edge points
                List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);
                quadTransformer.SourceQuadrilateral = corners; //Set corners for transforming card 
                quadTransformer.AutomaticSizeCalculaton = true;
                Bitmap cardImg = quadTransformer.Apply(source); //Extract(transform) card image

                if (cardImg.Width > cardImg.Height) //If card is positioned horizontally
                    cardImg.RotateFlip(RotateFlipType.Rotate90FlipNone); //Rotate
                cardImg = resizer.Apply(cardImg);
                ReadingCards.ImageProcessing.FileIOOperations.WriteImage(cardImg, Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), String.Format("{0}{1}{2}","FormatedImage",i,".png")));
                
            }
            return temp;
        }
    }
}
