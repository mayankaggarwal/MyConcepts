using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Spire.Pdf;
using ZXing;
using ZXing.Common;

namespace ReadingBarCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"D:\Learning\Repository\MyConcepts\Projects\ReadingCards\ReadingBarCodes\PDFs";
            string fileName = "A_codedcards.pdf";
            string fileToProcess = System.IO.Path.Combine(folder, fileName);
            Bitmap img = SavePDFImage(fileToProcess, folder) as Bitmap;

            Bitmap bmpImage = Image.FromFile(@"D:\Learning\Repository\MyConcepts\Projects\ReadingCards\ReadingBarCodes\PDFs\barcode.bmp") as Bitmap;
            string result = Process(bmpImage.Clone() as Bitmap);
            if (String.IsNullOrEmpty(result))
                Console.WriteLine("Not able to process");
            else
                Console.WriteLine("Processed Result" + result);

            Console.ReadLine();

        }

        //static Bitmap ConvertPDFToBitmap(string path)
        //{
        //    Bitmap originalImage = null;
        //    try
        //    {
        //        PdfReader reader = new PdfReader(path);
        //        PdfDictionary dict = reader.GetPageN(1);
        //        PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(dict.Get(PdfName.RESOURCES));
        //        PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));

        //        foreach (PdfName name in xobj.Keys)
        //        {
        //            PdfObject obj = xobj.Get(name);
        //            if (obj.IsIndirect())
        //            {
        //                PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
        //                string width = tg.Get(PdfName.WIDTH).ToString();
        //                string height = tg.Get(PdfName.HEIGHT).ToString();
        //                GraphicsState st = new GraphicsState();

        //                //ImageRenderInfo imgRI = ImageRenderInfo.CreateForXObject(, (PRIndirectReference)obj, tg);
        //                PdfImageObject image = imgRI.GetImage();

        //                using (Image img = image.GetDrawingImage())
        //                    originalImage = new Bitmap(img);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //System.Console.WriteLine("Improper document image");
        //        return null;
        //    }

        //    return originalImage;
        //}

        //static void SaveImg(string textFile,string outputPath)
        //{
        //    PdfReader pdf = new PdfReader(textFile);
        //    PdfDictionary pg = pdf.GetPageN(1);
        //    PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
        //    PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
        //    if (xobj == null) { return; }
        //    foreach (PdfName name in xobj.Keys)
        //    {
        //        PdfObject obj = xobj.Get(name);
        //        if (!obj.IsIndirect()) { continue; }
        //        PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
        //        PdfName type = (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
        //        if (!type.Equals(PdfName.IMAGE)) { continue; }
        //        int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
        //        PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
        //        PdfStream pdfStrem = (PdfStream)pdfObj;
        //        byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
        //        if (bytes == null) { continue; }
        //        using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes))
        //        {
        //            memStream.Position = 0;
        //            System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);
        //            if (!Directory.Exists(outputPath))
        //                Directory.CreateDirectory(outputPath);

        //            string path = System.IO.Path.Combine(outputPath, String.Format(@"{0}.jpg", 0));
        //            System.Drawing.Imaging.EncoderParameters parms = new System.Drawing.Imaging.EncoderParameters(1);
        //            parms.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
        //            var jpegEncoder = ImageCodecInfo.GetImageEncoders().ToList().Find(x => x.FormatID == ImageFormat.Jpeg.Guid);
        //            img.Save(path, jpegEncoder, parms);

        //        }
        //    }
        //}

        static Image SavePDFImage(string filePath, string outputDirectory)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(filePath);
            Image bmp = doc.SaveAsImage(0);
            bmp.Save(Path.Combine(outputDirectory, "temp.bmp"), ImageFormat.Bmp);
            return bmp;
        }

        static string Process(Bitmap bitmap)
        {
            try
            {
                LuminanceSource source = new BitmapLuminanceSource(bitmap);
                var binarizer = new HybridBinarizer(source);
                var binBitmap = new BinaryBitmap(binarizer);
                Result result = new MultiFormatReader().decode(binBitmap);
                if (result != null)
                {
                    return result.Text;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
