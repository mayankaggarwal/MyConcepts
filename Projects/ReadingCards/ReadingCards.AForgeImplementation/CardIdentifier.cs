using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using ReadingCards.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.AForgeImplementation
{
    public class CardIdentifier
    {
        private Bitmap j, k, q; //Face Card Character Templates
        private Bitmap clubs, diamonds, spades, hearts; //Suit Templates
        private FiltersSequence commonSeq; //Commonly filter sequence to be used 

        public CardIdentifier()
        {
            commonSeq = new FiltersSequence();
            commonSeq.Add(Grayscale.CommonAlgorithms.BT709);
            commonSeq.Add(new BradleyLocalThresholding());
            commonSeq.Add(new DifferenceEdgeDetector());

            
            //Load Templates From Resources , 
            //Templates will be used for template matching
            j = Resources.J;
            k = Resources.K;
            q = Resources.Q;
            clubs = Resources.Clubs;
            diamonds = Resources.Diamonds;
            spades = Resources.Spades;
            hearts = Resources.Hearts;
        }

        public Suit ScanFaceSuit(Bitmap bmp, char color)
        {
            //Initialize templateMatching class with 0.8 similarity threshold
            ExhaustiveTemplateMatching templateMatching = new ExhaustiveTemplateMatching(0.8f);
            Suit suit = Suit.NOT_RECOGNIZED;

            if (color == 'R') //If card is red then it can be hearts or diamonds
            {
                if (templateMatching.ProcessImage(bmp, hearts).Length > 0)
                    suit = Suit.Hearts; //Check If template matches for hearts
                if (templateMatching.ProcessImage(bmp, diamonds).Length > 0)
                    suit = Suit.Diamonds; //Check If template matches for diamonds
            }
            else //If its black
            {
                if (templateMatching.ProcessImage(bmp, spades).Length > 0)
                    suit = Suit.Spades; //Check If template matches for spades
                if (templateMatching.ProcessImage(bmp, clubs).Length > 0)
                    suit = Suit.Clubs;//Check If template matches for clubs
            }
            return suit;
        }

        public Suit ScanSuit(Bitmap suitBmp, char color)
        {
            Bitmap temp = commonSeq.Apply(suitBmp);
            ExtractBiggestBlob extractor = new ExtractBiggestBlob(); //Extract biggest blob on card
            temp = extractor.Apply(temp);  //Biggest blob is suit blob so extract it
            Suit suit = Suit.NOT_RECOGNIZED;

            //Determine type of suit according to its color and width
            if (color == 'R')
                suit = temp.Width >= 55 ? Suit.Diamonds : Suit.Hearts;
            if (color == 'B')
                suit = temp.Width <= 48 ? Suit.Spades : Suit.Clubs;

            return suit;
        }

        public Rank ScanFaceRank(Bitmap bmp)
        {
            //Initiliaze template matching class with 0.75 threshold
            ExhaustiveTemplateMatching templateMatchin = new ExhaustiveTemplateMatching(0.75f);
            Rank rank = Rank.NOT_RECOGNIZED;

            if (templateMatchin.ProcessImage(bmp, j).Length > 0) //If Jack template matches
                rank = Rank.Jack;
            if (templateMatchin.ProcessImage(bmp, k).Length > 0)//If King template matches
                rank = Rank.King;
            if (templateMatchin.ProcessImage(bmp, q).Length > 0)//If Queen template matches
                rank = Rank.Queen;

            return rank;
        }

        public Rank ScanRank(Bitmap cardImage)
        {
            Rank rank = Rank.NOT_RECOGNIZED;

            int total = 0;
            Bitmap temp = commonSeq.Apply(cardImage); //Apply filters on image

            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            //Filter blobs whose width or height less than 30 pixels
            blobCounter.MinHeight = blobCounter.MinWidth = 20;
            blobCounter.ProcessImage(temp);

            total = blobCounter.GetObjectsInformation().Length; //Get total number of objects

            rank = (Rank)total; //Convert it to Rank

            return rank;
        }

        public bool IsFaceCard(Bitmap bmp)
        {
            Bitmap temp = this.commonSeq.Apply(bmp);
            ExtractBiggestBlob extractor = new ExtractBiggestBlob();
            temp = extractor.Apply(temp); //Extract biggest blob

            if (temp.Width > bmp.Width / 2)  //If width is larger than half width of card
                return true; //Its a face card

            return false;  //It is not a face card
        }

        public char ScanColor(Bitmap bmp)
        {
            char color = 'B';
            //Crop rank part
            Crop crop = new Crop(new Rectangle(0, bmp.Height / 2, bmp.Width, bmp.Height / 2));
            bmp = crop.Apply(bmp);
            Bitmap temp = commonSeq.Apply(bmp); //Apply filters

            //Find suit blob on image
            BlobCounter counter = new BlobCounter();
            counter.ProcessImage(temp);
            Blob[] blobs = counter.GetObjectsInformation();

            if (blobs.Length > 0) //If blobs found
            {
                Blob max = blobs[0];
                //Find blob whose size is biggest 
                foreach (Blob blob in blobs)
                {
                    if (blob.Rectangle.Height > max.Rectangle.Height)
                        max = blob;
                    else if (blob.Rectangle.Height == max.Rectangle.Height)
                        max = blob.Rectangle.Width > max.Rectangle.Width ? blob : max;
                }
                QuadrilateralTransformation trans = new QuadrilateralTransformation();
                trans.SourceQuadrilateral = PointsCloud.FindQuadrilateralCorners(counter.GetBlobsEdgePoints(max));
                bmp = trans.Apply(bmp); //Extract suit
            }
            //Lock Bits for processing
            BitmapData imageData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
               ImageLockMode.ReadOnly, bmp.PixelFormat);
            int totalRed = 0;
            int totalBlack = 0;

            unsafe
            {
                //Count red and black pixels
                try
                {
                    UnmanagedImage img = new UnmanagedImage(imageData);

                    int height = img.Height;
                    int width = img.Width;
                    int pixelSize = (img.PixelFormat == PixelFormat.Format24bppRgb) ? 3 : 4;
                    byte* p = (byte*)img.ImageData.ToPointer();

                    // for each line
                    for (int y = 0; y < height; y++)
                    {
                        // for each pixel
                        for (int x = 0; x < width; x++, p += pixelSize)
                        {
                            int r = (int)p[RGB.R]; //Red pixel value
                            int g = (int)p[RGB.G]; //Green pixel value
                            int b = (int)p[RGB.B]; //Blue pixel value

                            if (r > g + b) //If red component is bigger then total of green and blue component
                                totalRed++;  //then its red

                            if (r <= g + b && r < 50 && g < 50 && b < 50) //If all components less 50
                                totalBlack++; //then its black
                        }
                    }

                }
                finally
                {
                    bmp.UnlockBits(imageData); //Unlock
                }
            }
            if (totalRed > totalBlack) //If red is dominant
                color = 'R'; //Set color as Red

            return color;
        }
    }
}
