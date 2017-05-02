using ReadingCards.IImageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingCards.Entities;
using System.Drawing;
using AForge.Imaging.Filters;

namespace ReadingCards.ImageProcessing.AForgeImplementation
{
    public class ImageProcessingAForgeOps : ImageProcessingOps
    {
        public override Bitmap ConvertImage(Bitmap source)
        {
            Bitmap returnValue;
            using (Bitmap temp = source.Clone() as Bitmap) //Clone image to keep original image
            {
                FiltersSequence seq = new FiltersSequence();
                seq.Add(Grayscale.CommonAlgorithms.BT709);  //First add  GrayScaling filter
                seq.Add(new GaussianBlur());
                seq.Add(new OtsuThreshold()); //Then add binarization(thresholding) filter
                returnValue = seq.Apply(temp); // Apply filters on source image
            }

            return returnValue;
            //BlobCounter extractor = new BlobCounter();
            //extractor.FilterBlobs = true;

            //extractor.MinWidth = extractor.MinHeight = 100;
            //extractor.MaxWidth = extractor.MaxHeight = 200;
            //extractor.ProcessImage(temp);
            //QuadrilateralTransformation quadTransformer = new QuadrilateralTransformation();
            ////Will be used resize(scaling) cards
            //ResizeBilinear resizer = new ResizeBilinear(100, 150);
            //int i = 0;
            //foreach (Blob blob in extractor.GetObjectsInformation())
            //{
            //    i++;
            //    //Get Edge points of card
            //    List<IntPoint> edgePoints = extractor.GetBlobsEdgePoints(blob);
            //    //Find corners of card on source image from edge points
            //    List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);
            //    quadTransformer.SourceQuadrilateral = corners; //Set corners for transforming card 
            //    quadTransformer.AutomaticSizeCalculaton = true;
            //    Bitmap cardImg = quadTransformer.Apply(source); //Extract(transform) card image

            //    if (cardImg.Width > cardImg.Height) //If card is positioned horizontally
            //        cardImg.RotateFlip(RotateFlipType.Rotate90FlipNone); //Rotate
            //    cardImg = resizer.Apply(cardImg);
            //    ReadingCards.ImageProcessing.FileIOOperations.WriteImage(cardImg, Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), String.Format("{0}{1}{2}","FormatedImage",i,".png")));

            //}
        }

        //public string DrawRectangle(List<CardBlob> rectangles, string imagePath)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<System.Drawing.Bitmap> ExtractRectangle(List<CardBlob> rectangles, System.Drawing.Bitmap bitmapImage)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
