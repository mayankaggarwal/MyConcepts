using IDW.Data;
using IDW.Data.Infrastructure;
using IDW.Data.Repositories;
using IDW.Entities.Plazza;
using IDWVisualization.DataAccessLayer.Repositories;
using IDWVisualization.DataAccessLayer.RepositoryInterfaces;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //EntityCountryRepository repo = new EntityCountryRepository();
            //var result = repo.Get();

            //IPZProfileRepository repo = new PZProfileRepository();
            ////var result = repo.Get(109439);

            //var result = repo.GetStats();

            //string firstText = DateTime.Now.ToShortDateString();

            //PointF firstLocation = new PointF(285f, 4f);

            //string imageFilePath = @"C:\Users\LJLZ1258\Desktop\image1.png";
            //string imageFilePath1 = @"C:\Users\LJLZ1258\Desktop\image2.png";
            //Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file

            //using (Graphics graphics = Graphics.FromImage(bitmap))
            //{
            //    using (Font arialFont = new Font("Arial", 10))
            //    {
            //        graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation);
            //    }
            //}

            //bitmap.Save(imageFilePath1);

            //IDbFactory dbFactory = new DbFactory();
            //IEntityBaseRepository<UserProfile> userprofileRepository = new EntityBaseRepository<UserProfile>(dbFactory);
            //var result = userprofileRepository.GetAll().ToList();

            //string filePath = "Image/TemplateEnglish.jpg";
            //string filePath = @"C:\D\Learning\Repository\MyConcepts\Projects\Visualization\IDWVisualization\IDWVisualization.App\Images\TemplateEnglish.jpg";
            //string fileSavePath = "Image/TemplateEnglish2.jpg";

            string filePath = @"C:\D\Learning\Repository\MyConcepts\Projects\Visualization\IDWVisualization\IDWVisualization.App\Images\PlazzaImage.png";
            string fileSavePath = @"C:\D\Learning\Repository\MyConcepts\Projects\Visualization\IDWVisualization\IDWVisualization.App\Images\PlazzaImage1.png";

            if (File.Exists(filePath))
            {

                CvMat mat = new CvMat(filePath);

                mat.PutText(DateTime.Now.ToShortDateString(), new CvPoint(285, 22), new CvFont(FontFace.HersheyDuplex, .1, .6, 0, 1, LineType.AntiAlias), new CvScalar(0, 0, 0));
                mat.PutText("86195", new CvPoint(92, 210), new CvFont(FontFace.HersheyDuplex, 0.5, 0.8, 0, 1, LineType.AntiAlias), new CvScalar(12, 105, 223));
                mat.PutText("36382", new CvPoint(189, 235), new CvFont(FontFace.HersheyDuplex, 0.5, 0.8, 0, 1, LineType.AntiAlias), new CvScalar(12, 105, 223));
                mat.PutText("42%", new CvPoint(197, 265), new CvFont(FontFace.HersheyDuplex, 0.5, 0.8, 0, 1, LineType.AntiAlias), new CvScalar(12, 105, 223));
                mat.PutText("13839", new CvPoint(106, 380), new CvFont(FontFace.HersheyDuplex, 0.5, 0.8, 0, 1, LineType.AntiAlias), new CvScalar(12, 105, 223));
                mat.PutText("930182", new CvPoint(42, 435), new CvFont(FontFace.HersheyDuplex, 0.5, 0.8, 0, 1, LineType.AntiAlias), new CvScalar(12, 105, 223));
                mat.PutText("0", new CvPoint(40, 480), new CvFont(FontFace.HersheyDuplex, 0.5, 0.8, 0, 1, LineType.AntiAlias), new CvScalar(12, 105, 223));
                mat.SaveImage(fileSavePath);

                Console.WriteLine("true");


                ////var mat = Cv2.ImRead(filePath,LoadMode.Unchanged);;
                //Cv.Mat mat = new Cv.Mat(filePath);
                ////mat.PutText("1234", new OpenCvSharp.CPlusPlus.Point(817, 1372), FontFace.HersheyPlain, 10, 12, 1, LineType.Link8, false);

                //mat.PutText("1234", new CvPoint(817, 1372), new CvFont(FontFace.HersheyPlain, 1, 1), new CvScalar(255, 0, 0));

                //Cv2.ImWrite(fileSavePath, mat);
                ////mat.SaveImage(fileSavePath);

            }
            else
                Console.WriteLine("false");
            Console.ReadLine();
        }
    }
}