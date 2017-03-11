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
    public static class FileIOOperations
    {
        public static Bitmap ReadImage(string imagePath)
        {
            if (!String.IsNullOrEmpty(imagePath))
            {
                if (File.Exists(imagePath))
                {
                    return (Bitmap)Bitmap.FromFile(imagePath);
                }
                else
                    return null;
            }
            else
                return null;
        }

        public static bool WriteImage(Bitmap image, string filePath)
        {
            if (!String.IsNullOrEmpty(filePath))
            {
                if (!File.Exists(filePath))
                {
                    if(image!=null)
                    {
                        using (var stream = new MemoryStream())
                        {
                            using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
                            {
                                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] bytes = stream.ToArray();
                                fs.Write(bytes, 0, bytes.Length);
                            }
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
