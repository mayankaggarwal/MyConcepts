using ReadingCards.AForgeImplementation;
using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.codeproject.com/script/Articles/ArticleVersion.aspx?aid=265354&av=443428
            //https://channel9.msdn.com/coding4fun/blog/Forging-Player-Card-Detection-and-Recognition-program-with-AForgeNet
            //http://mikhail.io/2016/02/building-a-poker-bot-card-recognition/
            ReadCardValue();
            Console.ReadLine();
        }

        private static void ReadCardValue()
        {
            ImageSource imageSource = new ImageSource();
            ImageFormatter imageFormatter = new ImageFormatter();
            
            

            string fileFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(fileFolder, "Resources\\draw-card.png");
            imageSource.AddImage(ImageType.SourceImage,ReadingCards.ImageProcessing.FileIOOperations.ReadImage(filePath));
            if (imageSource.imageSources[ImageType.SourceImage] == null)
                return;

            imageSource.AddImage(ImageType.BinaryImage, imageFormatter.GetBinaryImage(imageSource.imageSources[ImageType.SourceImage]));
            if (imageSource.imageSources[ImageType.BinaryImage] == null)
                return;

            #region "Card detection"
            CardDetector cardDetector = new CardDetector(BlobDetectionAlgorithmType.CCL, 50, 205, 100, 205);
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
                char color = cardIdentifier.ScanColor(cardItem.CardImage);
                bool isFaceCard = cardIdentifier.IsFaceCard(cardItem.CardImage);
                if (!isFaceCard)
                {
                    cardItem.suit = cardIdentifier.ScanSuit(cardItem.CardImage, color); //Scan Suit of non-face card
                    cardItem.rank = cardIdentifier.ScanRank(cardItem.CardImage); //Scan Rank of non-face card
                }
                Console.WriteLine(color + " " + isFaceCard + " " + cardItem.suit + " "  + cardItem.rank);
            }
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


    }
}
