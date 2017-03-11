using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.ImageProcessing
{
    public class ImageProcessingOperations
    {
        public string DrawRectangle(List<ReadingCards.Entities.CardBlob> rectangles, Bitmap image)
        {
            string imageResult = "";
            byte[] bytes;
            using(var stream = new MemoryStream())
            {
                image.Save(stream,ImageFormat.Bmp);
                bytes = stream.ToArray();
            }
            CvMat imageLocal;
            using (MemoryStream md = new MemoryStream(bytes))
            {
                imageLocal = new CvMat.FromStream(md, LoadMode.Unchanged);
            }

            IplImage iplImage = BitmapConverter.ToIplImage(image);

        

            CvScalar scaler = new CvScalar(255, 0, 0);
            for (int i = 0; i < rectangles.Count; i++)
            {
                CvPoint point = new CvPoint(rectangles[i].X, rectangles[i].Y);
                CvSize size = new CvSize(rectangles[i].Width, rectangles[i].Height);
                CvRect rect = new CvRect(point, size);
                Cv.Rectangle(imageLocal, rect, scaler, 5);
            }


            byte[] imageBytes = imageLocal.ToBytes(".png");
            imageResult = Convert.ToBase64String(imageBytes);
            imageLocal.Dispose();
            return imageResult;

        }

    
    }
}
