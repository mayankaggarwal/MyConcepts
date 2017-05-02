using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.IOOperations
{
    public class FileIOOperations
    {
        public Bitmap ReadImage(string imagePath)
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

        public bool WriteImage(Bitmap image, string filePath)
        {
            if (!String.IsNullOrEmpty(filePath))
            {
                if (!File.Exists(filePath))
                {
                    if (image != null)
                    {
                        using (var stream = new MemoryStream())
                        {
                            using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
                            {
                                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] bytes = stream.ToArray();
                                fs.Write(bytes, 0, bytes.Length);
                            }

                            //image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            //var img = Image.FromStream(stream);
                            //img.Save(filePath);

                            //image.Save(filePath);


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
