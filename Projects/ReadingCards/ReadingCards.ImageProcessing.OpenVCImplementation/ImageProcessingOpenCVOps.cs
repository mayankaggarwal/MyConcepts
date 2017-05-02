using ReadingCards.IImageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingCards.Entities;
using OpenCvSharp;
using System.Drawing;
using System.IO;

namespace ReadingCards.ImageProcessing.OpenVCImplementation
{
    public class ImageProcessingOpenCVOps : IImageProcessing.ImageProcessingOps
    {
        public override string DrawRectangle(List<CardBlob> rectangles, string imagePath)
        {
            //IplImage image = IplImage.FromFile(imagePath);
            //string imageResult = "";

            //CvMat imageLocal = CvMat.FromFile(imagePath);

            //CvScalar scaler = new CvScalar(255, 0, 0);
            //for (int i = 0; i < rectangles.Count; i++)
            //{
            //    CvPoint point = new CvPoint(rectangles[i].LeftBottomCorner.X, rectangles[i].LeftBottomCorner.Y);
            //    CvSize size = new CvSize(rectangles[i].Width, rectangles[i].Height);
            //    CvRect rect = new CvRect(point, size);
            //    Cv.Rectangle(imageLocal, rect, scaler, 5);
            //}

            //byte[] imageBytes = imageLocal.ToBytes(".png");
            //imageResult = Convert.ToBase64String(imageBytes);
            //imageLocal.Dispose();
            //return imageResult;

            return "";
        }

        public override List<Bitmap> ExtractRectangle(List<CardBlob> rectangles, Bitmap bitmapImage)
        {
            List<Bitmap> imageSamples = new List<Bitmap>();
            foreach (var cardBlob in rectangles)
            {
                imageSamples.Add(bitmapImage.Clone(new Rectangle
                {
                    X = cardBlob.LeftBottomCorner.X,
                    Y = cardBlob.LeftBottomCorner.Y,
                    Width = cardBlob.Width,
                    Height = cardBlob.Height
                }, bitmapImage.PixelFormat));
            }

            return imageSamples;

            //return image.ToBitmap();
        }

        public CvMat BitmapToMat(Bitmap bitmap)
        {          
            bitmap.Save("temp");
            CvMat mat1 = new CvMat("temp");
            return mat1;
            //IplImage tmp = new IplImage();

            //System.Drawing.Imaging.BitmapData bmData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
            //if (bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            //{
            //    tmp = Cv.CreateImage(new CvSize(bitmap.Width, bitmap.Height), BitDepth.U8, 1);
            //    tmp.ImageData = bmData.Scan0;
            //}

            //else if (bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            //{
            //    tmp = Cv.CreateImage(new CvSize(bitmap.Width, bitmap.Height), BitDepth.U8, 3);
            //    tmp.ImageData = bmData.Scan0;
            //}

            //bitmap.UnlockBits(bmData);
            //CvMat mat = new CvMat();
            //Cv.Convert(tmp, mat);


            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            System.Drawing.Imaging.BitmapData bmpData =
                bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bitmap.PixelFormat);

            // data = scan0 is a pointer to our memory block.
            IntPtr data = bmpData.Scan0;

            // step = stride = amount of bytes for a single line of the image
            int step = bmpData.Stride;

            // So you can try to get you Mat instance like this:
            CvMat mat = new CvMat(bitmap.Height, bitmap.Width,MatrixType.F32C4, data);

            // Unlock the bits.
            bitmap.UnlockBits(bmpData);
            return mat;
        }

        public Bitmap MatToBitmap(CvMat srcImg)
        {
            if (File.Exists("temp_cvMat.jpg"))
            {
                File.Delete("temp_cvMat.jpg");
            }
            srcImg.Clone().SaveImage("temp_cvMat.jpg");
            return new Bitmap("temp_cvMat.jpg").Clone() as Bitmap;
            //return new Bitmap(srcImg.Cols, srcImg.Rows, 4 * srcImg.Rows, System.Drawing.Imaging.PixelFormat.Format32bppArgb, srcImg.Data);
            //int stride = srcImg.GetSize().Width * srcImg.ElemChannels;//calc the srtide
            //int hDataCount = srcImg.size().height;

            //System::Drawing::Bitmap ^ retImg;

            //System::IntPtr ptr(srcImg.data);

            ////create a pointer with Stride
            //if (stride % 4 != 0)
            //{//is not stride a multiple of 4?
            // //make it a multiple of 4 by fiiling an offset to the end of each row

            //    //to hold processed data
            //    uchar* dataPro = new uchar[((srcImg.size().width * srcImg.channels() + 3) & -4) * hDataCount];

            //    uchar* data = srcImg.ptr();

            //    //current position on the data array
            //    int curPosition = 0;
            //    //current offset
            //    int curOffset = 0;

            //    int offsetCounter = 0;

            //    //itterate through all the bytes on the structure
            //    for (int r = 0; r < hDataCount; r++)
            //    {
            //        //fill the data
            //        for (int c = 0; c < stride; c++)
            //        {
            //            curPosition = (r * stride) + c;

            //            dataPro[curPosition + curOffset] = data[curPosition];
            //        }

            //        //reset offset counter
            //        offsetCounter = stride;

            //        //fill the offset
            //        do
            //        {
            //            curOffset += 1;
            //            dataPro[curPosition + curOffset] = 0;

            //            offsetCounter += 1;
            //        } while (offsetCounter % 4 != 0);
            //    }

            //    ptr = (System::IntPtr)dataPro;//set the data pointer to new/modified data array

            //    //calc the stride to nearest number which is a multiply of 4
            //    stride = (srcImg.size().width * srcImg.channels() + 3) & -4;

            //    retImg = gcnew System::Drawing::Bitmap(srcImg.size().width, srcImg.size().height,
            //        stride,
            //        System::Drawing::Imaging::PixelFormat::Format24bppRgb,
            //        ptr);
            //}
            //else
            //{

            //    //no need to add a padding or recalculate the stride
            //    retImg = gcnew System::Drawing::Bitmap(srcImg.size().width, srcImg.size().height,
            //        stride,
            //        System::Drawing::Imaging::PixelFormat::Format24bppRgb,
            //        ptr);
            //}

            //array ^ imageData;
            //System::Drawing::Bitmap ^ output;

            //// Create the byte array.
            //{
            //    System::IO::MemoryStream ^ ms = gcnew System::IO::MemoryStream();
            //    retImg->Save(ms, System::Drawing::Imaging::ImageFormat::Png);
            //    imageData = ms->ToArray();
            //    delete ms;
            //}

            //// Convert back to bitmap
            //{
            //    System::IO::MemoryStream ^ ms = gcnew System::IO::MemoryStream(imageData);
            //    output = (System::Drawing::Bitmap ^)System::Drawing::Bitmap::FromStream(ms);
            //}

            //return output;
        }

        public Bitmap GetCannyEdge(Bitmap srcImg)
        {
            IplImage iplImage = OpenCvSharp.Extensions.BitmapConverter.ToIplImage(srcImg);

            using (IplImage dst = new IplImage(iplImage.Size, BitDepth.U8, 1))
            {
                iplImage.Canny(dst, 100, 200);
                using (new CvWindow("src image", iplImage))
                using (new CvWindow("dst image", dst))
                {
                    Cv.WaitKey();
                }
                return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst);
     //           return dst;
            }

            //iplImage.Canny(destImg, 10, 30);


            //int i = 1;
            //while (!File.Exists("cannyiplimage" + i + ".jpg"))
            //{
            //    i++;
            //}
            //destImg.SaveImage("cannyiplimage" + i + ".jpg");
            //return destImg;

            //IplImage img = new IplImage();
            //Cv.Canny(srcImg, img, 1, 10);
            //int i = 1;
            //while(!File.Exists("cannyimage" + i + ".jpg"))
            //{
            //    i++;
            //}
            //img.SaveImage("cannyimage" + i + ".jpg");
            //return destImg;
        }

        public CvMat GetCannyEdge(CvMat srcImg)
        {
            CvMat img = new CvMat(false);

            Cv.Canny(srcImg, img, 1, 10);
            int i = 1;
            while (!File.Exists("cannyimage" + i + ".jpg"))
            {
                i++;
            }
            img.SaveImage("cannyimage" + i + ".jpg");
            return img;
        }
    }
}
