using AForge;
using AForge.Imaging.Filters;
using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.AForgeImplementation
{
    public class ImageFormatter
    {
        public Bitmap GetGrayScaleImge(Bitmap image)
        {
            Bitmap temp = image.Clone() as Bitmap;
            FiltersSequence seq = new FiltersSequence();
            seq.Add(Grayscale.CommonAlgorithms.BT709);  //First add  GrayScaling filter
            temp = seq.Apply(image);
            return temp;
        }

        public Bitmap GetBinaryImageFromGrayScale(Bitmap image)
        {
            Bitmap temp = image.Clone() as Bitmap;
            FiltersSequence seq = new FiltersSequence();
            seq.Add(new OtsuThreshold()); //Then add binarization(thresholding) filter
            temp = seq.Apply(image); // Apply filters on source image
            return temp;
        }

        public Bitmap GetBinaryImage(Bitmap image)
        {
            //Bitmap temp = image.Clone() as Bitmap;
            Bitmap temp = AForge.Imaging.Image.Clone(image,PixelFormat.Format32bppArgb);
            //AForge.Imaging.Image.SetGrayscalePalette(temp);
            FiltersSequence seq = new FiltersSequence();
            seq.Add(Grayscale.CommonAlgorithms.BT709);  //First add  GrayScaling filter
            seq.Add(new OtsuThreshold()); //Then add binarization(thresholding) filter
    
            //GrayscaleBT709 gsb = new GrayscaleBT709();
            //gsb.AssertCanApply(temp.PixelFormat);
            Bitmap temp1 = seq.Apply(temp); // Apply filters on source image
            return temp1;
        }

        public Bitmap SubsetImage(Bitmap sourceImage,CardBlob cardBlob)
        {
            QuadrilateralTransformation quadTransformer = new QuadrilateralTransformation();
            List<IntPoint> corners = new List<IntPoint>();
            corners.Add(new IntPoint
            {
                X = cardBlob.LeftTopCorner.X,
                Y = cardBlob.LeftTopCorner.Y
            });
            corners.Add(new IntPoint
            {
                X = cardBlob.LeftBottomCorner.X,
                Y = cardBlob.LeftBottomCorner.Y
            });
            corners.Add(new IntPoint
            {
                X = cardBlob.RightTopCorner.X,
                Y = cardBlob.RightTopCorner.Y
            });
            corners.Add(new IntPoint
            {
                X = cardBlob.RightBottomCorner.X,
                Y = cardBlob.RightBottomCorner.Y
            });
            quadTransformer.SourceQuadrilateral = corners;
            quadTransformer.AutomaticSizeCalculaton = true;
            return quadTransformer.Apply(sourceImage);
        }

        public Bitmap ResizeImage(Bitmap sourceImage,int height,int width)
        {
            ResizeBilinear resizer = new ResizeBilinear(width, height);
            return resizer.Apply(sourceImage);
        }

    }

    public static class AForgeUtility
    {

        /// <summary>
        /// Makes a debug assertion that an image filter that implements 
        /// the <see cref="IFilterInformation"/> interface can 
        /// process an image with the specified <see cref="PixelFormat"/>.
        /// </summary>
        /// <param name="filterInfo">The filter under consideration.</param>
        /// <param name="format">The PixelFormat under consideration.</param>
        [Conditional("DEBUG")]
        public static void AssertCanApply(
            this IFilterInformation filterInfo,
            PixelFormat format)
        {
          

                Console.WriteLine(string.Format("{0} cannot process an image "
                    + "with the provided pixel format.  Provided "
                    + "format: {1}.  Accepted formats: {2}.",
                    filterInfo.GetType().Name,
                    format.ToString(),
                    string.Join(", ", filterInfo.FormatTranslations.Keys)));
        }
    }
}
