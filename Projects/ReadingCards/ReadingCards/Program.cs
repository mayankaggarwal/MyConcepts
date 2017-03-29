using ReadingCards.AForgeImplementation;
using ReadingCards.Entities;
using ReadingCards.IOOperations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(fileFolder, "Resources\\cards4.png");
            ReadCardValue(filePath);
            //int i = 1;
            //string folderPath =@"D:\Learning\Repository\MyConcepts\Projects\ReadingCards\ReadingCards\Resources";
            //string[] fileNames = { "cards1.png", "cards2.jpg", "cards3.jpg", "cards4.png", "cards5.jpg" };
            //string filePath = "";
            //string outPutFilePath = "";

            //for (i = 1; i <= 4; i++)
            //{
            //    filePath = Path.Combine(folderPath, fileNames[i]);
            //    outPutFilePath = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(fileNames[i]) + "_output2" + Path.GetExtension(fileNames[i]));
            //    ReadCard(filePath, outPutFilePath);
            //}
            Console.WriteLine("Press enter to stop");
            Console.ReadLine();
        }

        private static void ReadCardValue(string filePath)
        {
            ImageSource imageSource = new ImageSource();
            ImageFormatter imageFormatter = new ImageFormatter();
            FileIOOperations fileIOOperations = new FileIOOperations();


            string fileFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string filePath = Path.Combine(fileFolder, "Resources\\cards4.png");
            imageSource.AddImage(ImageType.SourceImage, fileIOOperations.ReadImage(filePath));
            if (imageSource.imageSources[ImageType.SourceImage] == null)
                return;

            imageSource.AddImage(ImageType.BinaryImage, imageFormatter.GetBinaryImage(imageSource.imageSources[ImageType.SourceImage]));
            if (imageSource.imageSources[ImageType.BinaryImage] == null)
                return;

            #region "Card detection"
            CardDetector cardDetector = new CardDetector(BlobDetectionAlgorithmType.CCL, 50, 2050, 100, 2050);
            List<CardBlob> cardBlobs = new List<CardBlob>();
            cardBlobs.AddRange(cardDetector.GetBlobs(imageSource.imageSources[ImageType.BinaryImage]));
            Console.WriteLine(cardBlobs.Count());

            foreach(CardBlob cardBlob in cardBlobs)
            {
                imageSource.AddCardItem(new CardItem(cardBlob, imageFormatter.SubsetImage(imageSource.imageSources[ImageType.SourceImage], cardBlob)));
            }
            #endregion

            #region "Card Recognition"
            CardIdentifier cardIdentifier = new CardIdentifier();
            foreach (CardItem cardItem in imageSource.cardItems)
            {
                char color = 'A';
                color = cardIdentifier.ScanColor(cardItem.CardImage);
                bool isFaceCard = cardIdentifier.IsFaceCard(cardItem.CardImage);
                if (!isFaceCard)
                {
                    cardItem.suit = cardIdentifier.ScanSuit(cardItem.CardImage, color); //Scan Suit of non-face card
                    cardItem.rank = cardIdentifier.ScanRank(cardItem.CardImage); //Scan Rank of non-face card
                }
                Console.WriteLine(color + " " + isFaceCard + " " + cardItem.suit + " "  + cardItem.rank);
            }

            IImageProcessing.ImageProcessingOps img = new ImageProcessing.AForgeImplementation.ImageProcessingAForgeOps();
            Bitmap result = img.DrawRectangle(imageSource.imageSources[ImageType.SourceImage], imageSource);

            result.Save("temp.png");
            #endregion

            Console.WriteLine(imageSource.cardItems.Count());
            //Bitmap formattedImage = ReadingCards.ImageProcessing.ImageFormatter.ConvertImage(image);
            //if (image == null)
            //    return;


           // Bitmap imageWithBlobs = ReadingCards.ImageProcessing.ImageBlobExtractor.ExtractBlobs(formattedImage);
            //if (imageWithBlobs != null)
            //ReadingCards.ImageProcessing.FileIOOperations.WriteImage(formattedImage, Path.Combine(fileFolder, "FormatedImage.png"));

            
            
            Console.WriteLine("true");
        }

        private static string ReadCard(string filePath,string outputFilePath)
        {
            string fileOutputPath = string.Empty;
            ImageSource imageSource = new ImageSource();
            FileIOOperations fileIOOperations = new FileIOOperations();

            imageSource.AddImage(ImageType.SourceImage, fileIOOperations.ReadImage(filePath));
            if (imageSource.imageSources[ImageType.SourceImage] == null)
                return null;

            IImageProcessing.ImageProcessingOps imageProcessingOps = new ImageProcessing.AForgeImplementation.ImageProcessingAForgeOps();
            imageSource.AddImage(ImageType.BinaryImage,imageProcessingOps.ConvertImage(imageSource.imageSources[ImageType.SourceImage]));
            if (imageSource.imageSources[ImageType.BinaryImage] == null)
                return null;

            ImageProcessing.OpenVCImplementation.ImageProcessingOpenCVOps imageProcessingOps1 = new ImageProcessing.OpenVCImplementation.ImageProcessingOpenCVOps();
            //imageProcessingOps1.GetCannyEdge(imageProcessingOps1.BitmapToMat(imageSource.imageSources[ImageType.SourceImage]));
            //fileIOOperations.WriteImage(test.Clone() as Bitmap, outputFilePath);
            imageProcessingOps1.GetCannyEdge(imageSource.imageSources[ImageType.SourceImage]);

            fileOutputPath = outputFilePath;
            return fileOutputPath;
        }

    }
}
