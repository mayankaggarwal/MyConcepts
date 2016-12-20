using IDW.ImageProcessing.Entities;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.ImageProcessing
{
    public class ImageOperationsOpenCV:IImageOperations
    {
        public string TempImageFolder { get; private set; }
        private Object lockobject = new Object();
        public ImageOperationsOpenCV(string tempImageFolder)
        {
            this.TempImageFolder = tempImageFolder;
        }

        public string WriteTextToImage(string sourceImagePath, List<Entities.TextDetails> lstTextDetails)
        {
            string destinationFilePath = string.Empty;
            if (File.Exists(sourceImagePath))
            {
                lock (lockobject)
                {
                    CvMat mat = new CvMat(sourceImagePath);

                    foreach (TextDetails textDetails in lstTextDetails)
                    {
                        mat.PutText(textDetails.Text,
                            new CvPoint(textDetails.TextPoint.X, textDetails.TextPoint.Y),
                            new CvFont(FontFace.HersheyDuplex, textDetails.TextScale.HScale, textDetails.TextScale.YScale, 0, textDetails.Thickness, LineType.AntiAlias),
                            new CvScalar(textDetails.FontColor.B, textDetails.FontColor.G, textDetails.FontColor.R));
                    }

                    string fileName = Path.GetFileNameWithoutExtension(sourceImagePath);
                    string extension = Path.GetExtension(sourceImagePath);

                    destinationFilePath = Path.Combine(this.TempImageFolder, String.Concat(fileName, "_Temp", extension));
                    mat.SaveImage(destinationFilePath);
                }
                return destinationFilePath;


                ////var mat = Cv2.ImRead(filePath,LoadMode.Unchanged);;
                //Cv.Mat mat = new Cv.Mat(filePath);
                ////mat.PutText("1234", new OpenCvSharp.CPlusPlus.Point(817, 1372), FontFace.HersheyPlain, 10, 12, 1, LineType.Link8, false);

                //mat.PutText("1234", new CvPoint(817, 1372), new CvFont(FontFace.HersheyPlain, 1, 1), new CvScalar(255, 0, 0));

                //Cv2.ImWrite(fileSavePath, mat);
                ////mat.SaveImage(fileSavePath);

            }
            else
            {
                return null;
            }
        }

        public string WriteTextToBase64Image(string sourceImageString, List<Entities.TextDetails> lstTextDetails)
        {
            throw new NotImplementedException();
        }
    }
}
