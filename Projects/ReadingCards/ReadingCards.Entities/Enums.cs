using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingCards.Entities
{
    public enum ImageType
    {
        SourceImage,
        GreyScaleImage,
        BinaryImage
    }

    public enum BlobDetectionAlgorithmType
    {
        CCL,
        RCCL
    }

    public enum Rank
    {
        NOT_RECOGNIZED = 0,
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    public enum Suit
    {
        NOT_RECOGNIZED = 0,
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public enum ProcessingEngine
    {
        DotNet,
        OpenCV,
        Aforge
    }
}
